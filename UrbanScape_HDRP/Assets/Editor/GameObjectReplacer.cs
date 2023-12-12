using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PlateauSamples.UrbanScape
{
    public class GameObjectReplacer : EditorWindow
    {
        static GameObjectReplacer s_Window;
        static GameObject[] s_GameObjects;
        static GameObject s_GameObjectReplacement;
        static bool s_CopyRotation, s_CopyScale;

        static Texture2D s_PrefabIcon;

        [MenuItem("Urban Scape/選択配置物を指定のプレハブに置換")]
        static void Init()
        {
            s_Window = GetWindow<GameObjectReplacer>("選択配置物を置換");
            s_GameObjectReplacement = null;
        }

        void OnEnable()
        {
            Init();
        }

        [System.Obsolete]
        void OnGUI()
        {
            s_GameObjects = Selection.gameObjects;

            GetLayoutHeader();
            GUILayout.Space(15);
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            GUILayout.BeginVertical();

            GetLayoutFields();

            GUILayout.Space(5);
            GUILayout.EndVertical();
            GUILayout.Space(10);
            GUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
            SceneView.RepaintAll();
        }

        [System.Obsolete]
        void Replace()
        {
            string prefabType = PrefabUtility.GetPrefabType(s_GameObjectReplacement).ToString();

            List<GameObject> newSelection = new List<GameObject>();
            foreach (GameObject gameObject in s_GameObjects)
            {
                if (gameObject == s_GameObjectReplacement)
                {
                    newSelection.Add(gameObject);
                    continue;
                }

                GameObject newGameObject = CreateReplacementGameObject(prefabType, gameObject);
                newSelection.Add(newGameObject);
            }

            Selection.objects = newSelection.ToArray();
            string goString = (newSelection.Count > 1) ? " GameObjects have " : " GameObject has ";
            Debug.Log(newSelection.Count + goString + "been replaced with: " + s_GameObjectReplacement.name + "\nPrefab Type: " + prefabType);
        }

        [System.Obsolete]
        GameObject CreateReplacementGameObject(string prefabType, GameObject original)
        {
            GameObject newGameObject;
            switch (prefabType)
            {
                case "PrefabInstance":
                    Object newPrefab = PrefabUtility.GetPrefabParent(s_GameObjectReplacement);
                    newGameObject = PrefabUtility.InstantiatePrefab(newPrefab) as GameObject;
                    PrefabUtility.SetPropertyModifications(newGameObject, PrefabUtility.GetPropertyModifications(s_GameObjectReplacement));
                    break;
                case "Prefab":
                    newGameObject = PrefabUtility.InstantiatePrefab(s_GameObjectReplacement) as GameObject;
                    break;
                default: // "None"
                    newGameObject = Instantiate(s_GameObjectReplacement);
                    newGameObject.name = s_GameObjectReplacement.name;
                    break;
            }

            Undo.RegisterCreatedObjectUndo(newGameObject, "created object");

            newGameObject.transform.position = original.transform.position;
            if (s_CopyRotation)
            {
                newGameObject.transform.rotation = original.transform.rotation;
            }

            if (s_CopyScale)
            {
                newGameObject.transform.localScale = original.transform.localScale;
            }

            newGameObject.transform.parent = original.transform.parent;

            Undo.DestroyObjectImmediate(original);
            return newGameObject;
        }

        void GetLayoutHeader()
        {
            GUILayout.Space(5);
            if (Event.current.type == EventType.Repaint && s_PrefabIcon == null)
            {
                s_PrefabIcon = EditorGUIUtility.FindTexture("PrefabNormal Icon");
            }
            if (s_PrefabIcon != null)
            {
                Rect iconRect = GUILayoutUtility.GetLastRect();
                iconRect.x += 4;
                iconRect.y += 1;
                iconRect.width = s_PrefabIcon.width / 3;
                iconRect.height = s_PrefabIcon.height / 3;
                GUI.DrawTexture(iconRect, s_PrefabIcon);
            }
        }

        [System.Obsolete]
        void GetLayoutFields()
        {
            EditorGUIUtility.labelWidth = 100;

            s_GameObjectReplacement = EditorGUILayout.ObjectField("置換するプレハブ", s_GameObjectReplacement, typeof(GameObject), true) as GameObject;
            s_CopyRotation = EditorGUILayout.Toggle("回転をコピー", s_CopyRotation);
            s_CopyScale = EditorGUILayout.Toggle("スケールをコピー", s_CopyScale);

            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("置換の実行", GUILayout.Width(75)) && s_GameObjects.Length != 0 && s_GameObjectReplacement != null)
            {
                Replace();
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}
