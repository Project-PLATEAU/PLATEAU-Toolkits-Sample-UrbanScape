using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace PlateauSamples.UrbanScape
{
    static class MeshUtilitiesEditor
    {
        [MenuItem("Urban Scape/選択階層配下の表示されているメッシュレンダラーを選択")]
        public static void SelectVisibleMeshRenderersMenu()
        {
            SelectVisibleMeshRenderers();
        }

        [MenuItem("Urban Scape/選択地物を原点に整列")]
        public static void AlignEachBottomToOriginMenu()
        {
            AlignEachBottomToOrigin();
        }

        [MenuItem("Urban Scape/選択したメッシュの結合")]
        public static void CombineSelectedMeshesMenu()
        {
            GameObject[] selectedObjects = Selection.gameObjects;
            if (selectedObjects.Length == 0)
            {
                EditorUtility.DisplayDialog("Error", "ゲームオブジェクトが選択されていません", "OK");
                return;
            }

            GameObject combinedMeshObject = CombineSelectedMeshes(selectedObjects);
            if (combinedMeshObject != null)
            {
                Selection.activeGameObject = combinedMeshObject;
            }
        }

        public static void SelectVisibleMeshRenderers()
        {
            GameObject[] selectedObjects = Selection.gameObjects;
            if (selectedObjects == null || selectedObjects.Length == 0)
            {
                EditorUtility.DisplayDialog("Error", "ゲームオブジェクトが選択されていません.", "OK");
                return;
            }

            var visibleMeshRenderers = new List<GameObject>();
            foreach (GameObject obj in selectedObjects)
            {
                CollectVisibleMeshRenderers(obj.transform, visibleMeshRenderers);
            }

            Selection.objects = visibleMeshRenderers.ToArray();
        }

        static void CollectVisibleMeshRenderers(Transform parent, List<GameObject> visibleMeshRenderers)
        {
            foreach (Transform child in parent)
            {
                MeshRenderer meshRenderer = child.GetComponent<MeshRenderer>();
                if (meshRenderer != null && meshRenderer.enabled)
                {
                    visibleMeshRenderers.Add(child.gameObject);
                }

                CollectVisibleMeshRenderers(child, visibleMeshRenderers);
            }
        }

        public static GameObject CombineSelectedMeshes(GameObject[] selectedObjects)
        {
            List<MeshFilter> meshFilters = new List<MeshFilter>();
            List<MeshRenderer> meshRenderers = new List<MeshRenderer>();

            foreach (GameObject obj in selectedObjects)
            {
                MeshFilter meshFilter = obj.GetComponent<MeshFilter>();
                MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();

                if (meshFilter != null && meshRenderer != null)
                {
                    meshFilters.Add(meshFilter);
                    meshRenderers.Add(meshRenderer);
                }
            }

            if (meshFilters.Count == 0 || meshRenderers.Count == 0)
            {
                Debug.LogError("選択したオブジェクトに MeshFiltersコンポーネント または MeshRendererコンポーネント が見つかりません。");
                return null;
            }

            return CombineMeshes(meshFilters, meshRenderers);
        }

        static void CollectMeshComponents(Transform parentTransform, List<MeshFilter> meshFilters, List<MeshRenderer> meshRenderers)
        {
            foreach (Transform child in parentTransform)
            {
                MeshFilter meshFilter = child.GetComponent<MeshFilter>();
                MeshRenderer meshRenderer = child.GetComponent<MeshRenderer>();
                if (meshFilter != null && meshRenderer != null)
                {
                    meshFilters.Add(meshFilter);
                    meshRenderers.Add(meshRenderer);
                }

                CollectMeshComponents(child, meshFilters, meshRenderers);
            }
        }

        public static GameObject CombineMeshes(List<MeshFilter> meshFilters, List<MeshRenderer> meshRenderers)
        {
            GameObject combinedMeshObject = new GameObject("CombinedMesh");
            Undo.RegisterCreatedObjectUndo(combinedMeshObject, "Combine Meshes");
            MeshFilter combinedMeshFilter = combinedMeshObject.AddComponent<MeshFilter>();
            MeshRenderer combinedMeshRenderer = combinedMeshObject.AddComponent<MeshRenderer>();

            var combineInstances = new List<CombineInstance>();
            var materialsList = new List<Material>();

            for (int i = 0; i < meshFilters.Count; i++)
            {
                Mesh mesh = meshFilters[i].sharedMesh;
                Material[] materials = meshRenderers[i].sharedMaterials;

                for (int j = 0; j < mesh.subMeshCount; j++)
                {
                    combineInstances.Add(new CombineInstance
                    {
                        mesh = mesh,
                        subMeshIndex = j,
                        transform = meshFilters[i].transform.localToWorldMatrix
                    });

                    if (j < materials.Length)
                    {
                        materialsList.Add(materials[j]);
                    }
                }
            }

            Mesh combinedMesh = new Mesh();
            combinedMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
            combinedMesh.CombineMeshes(combineInstances.ToArray(), false, true);
            combinedMeshFilter.sharedMesh = combinedMesh;
            combinedMeshRenderer.materials = materialsList.ToArray();

            ReCombineSubMeshes(combinedMeshObject);

            return combinedMeshObject;
        }

        static void ReCombineSubMeshes(GameObject combinedMeshObject)
        {
            MeshFilter combinedMeshFilter = combinedMeshObject.GetComponent<MeshFilter>();
            MeshRenderer combinedMeshRenderer = combinedMeshObject.GetComponent<MeshRenderer>();

            Mesh combinedMesh = combinedMeshFilter.sharedMesh;
            combinedMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
            Material[] materials = combinedMeshRenderer.sharedMaterials;

            var materialGroups = new Dictionary<Material, List<CombineInstance>>();

            for (int i = 0; i < combinedMesh.subMeshCount; i++)
            {
                Material mat = materials[i];
                if (!materialGroups.ContainsKey(mat))
                {
                    materialGroups[mat] = new List<CombineInstance>();
                }

                materialGroups[mat].Add(new CombineInstance
                {
                    mesh = combinedMesh,
                    subMeshIndex = i,
                    transform = Matrix4x4.identity
                });
            }

            var newCombineInstances = new List<CombineInstance>();
            var newMaterialsList = new List<Material>();

            foreach (KeyValuePair<Material, List<CombineInstance>> group in materialGroups)
            {
                Mesh newSubMesh = new Mesh();
                newSubMesh.CombineMeshes(group.Value.ToArray(), true, false);

                newCombineInstances.Add(new CombineInstance
                {
                    mesh = newSubMesh,
                    subMeshIndex = 0,
                    transform = Matrix4x4.identity
                });

                newMaterialsList.Add(group.Key);
            }

            Mesh finalMesh = new Mesh();
            finalMesh.CombineMeshes(newCombineInstances.ToArray(), false, false);
            combinedMeshFilter.sharedMesh = finalMesh;
            combinedMeshRenderer.materials = newMaterialsList.ToArray();
        }

        public static void AlignEachBottomToOrigin()
        {
            GameObject[] selectedObjects = Selection.gameObjects;
            if (selectedObjects == null || selectedObjects.Length == 0)
            {
                EditorUtility.DisplayDialog("エラー", "ゲームオブジェクトが選択されていません", "閉じる");
                return;
            }

            Undo.SetCurrentGroupName("Align Bottoms to Origin");
            int undoGroup = Undo.GetCurrentGroup();

            foreach (GameObject obj in selectedObjects)
            {
                AlignBottomToOrigin(obj);
            }

            Undo.CollapseUndoOperations(undoGroup);
        }

        public static void AlignBottomToOrigin(GameObject obj)
        {
            MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
            if (meshRenderer)
            {
                Bounds bounds = meshRenderer.bounds;
                float yOffset = bounds.min.y;

                Undo.RecordObject(obj.transform, "Align Bottom to Origin");

                Vector3 position = obj.transform.position;
                position.y -= yOffset;
                obj.transform.position = position;
            }
        }
    }
}
