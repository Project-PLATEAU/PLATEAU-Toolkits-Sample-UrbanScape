using UnityEngine;
using UnityEditor;

namespace PlateauSamples.UrbanScape
{
    public class FlattenMeshVertices : EditorWindow
    {
        float m_TargetHeight = 0.0f;

        [MenuItem("Urban Scape/メッシュ頂点を任意の高さで平面化")]
        static void Init()
        {
            FlattenMeshVertices window = (FlattenMeshVertices)EditorWindow.GetWindow(typeof(FlattenMeshVertices));
            window.Show();
        }

        void OnGUI()
        {
            EditorGUILayout.BeginVertical();

            m_TargetHeight = EditorGUILayout.FloatField("Target Height:", m_TargetHeight);

            if (GUILayout.Button("メッシュ頂点の平面化"))
            {
                FlattenSelectedMeshVertices();
            }

            EditorGUILayout.EndVertical();
        }

        void FlattenSelectedMeshVertices()
        {
            Debug.Log($"Number of selected objects: {Selection.gameObjects.Length}");

            foreach (GameObject selectedObject in Selection.gameObjects)
            {
                Debug.Log($"Processing object: {selectedObject.name}");

                MeshFilter meshFilter = selectedObject.GetComponent<MeshFilter>();
                if (meshFilter)
                {
                    Mesh newMesh = Object.Instantiate(meshFilter.sharedMesh);
                    Vector3[] vertices = newMesh.vertices;

                    for (int i = 0; i < vertices.Length; i++)
                    {
                        Vector3 flattenedPosition = selectedObject.transform.TransformPoint(vertices[i]);
                        flattenedPosition.y = m_TargetHeight;
                        vertices[i] = selectedObject.transform.InverseTransformPoint(flattenedPosition);
                    }

                    newMesh.vertices = vertices;
                    newMesh.RecalculateBounds();
                    newMesh.RecalculateNormals();

                    Undo.RecordObject(meshFilter, "Flatten Mesh Vertices");
                    meshFilter.sharedMesh = newMesh;

                    MeshCollider meshCollider = selectedObject.GetComponent<MeshCollider>();
                    if (meshCollider)
                    {
                        Undo.RecordObject(meshCollider, "Update Mesh Collider");
                        meshCollider.sharedMesh = newMesh;
                    }
                }
                else
                {
                    Debug.LogWarning($"No MeshFilter found on {selectedObject.name}");
                }
            }
        }
    }
}
