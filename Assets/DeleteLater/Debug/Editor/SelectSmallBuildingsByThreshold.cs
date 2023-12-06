using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class SelectSmallBuildingsWindow : EditorWindow
{
    float m_SizeThreshold = 3.0f;

    [MenuItem("Tools/Select Small Buildings with Prefix")]
    public static void ShowWindow()
    {
        GetWindow<SelectSmallBuildingsWindow>("Select Small Buildings");
    }

    void OnGUI()
    {
        GUILayout.Label("Select Small Buildings", EditorStyles.boldLabel);
        m_SizeThreshold = EditorGUILayout.FloatField("Size Threshold", m_SizeThreshold);

        if (GUILayout.Button("Select Buildings"))
        {
            SelectBuildings();
        }
    }

    void SelectBuildings()
    {
        if (Selection.activeTransform == null)
        {
            Debug.LogWarning("No GameObject selected.");
            return;
        }

        List<GameObject> smallBuildings = new List<GameObject>();
        FindSmallBuildings(Selection.activeTransform, m_SizeThreshold, smallBuildings);

        if (smallBuildings.Count > 0)
        {
            Selection.objects = smallBuildings.ToArray();
        }
        else
        {
            Debug.Log("No small buildings found under the selected object.");
        }
    }

    static void FindSmallBuildings(Transform parent, float threshold, List<GameObject> foundBuildings)
    {
        foreach (Transform child in parent)
        {
            if (child.name.StartsWith("bldg"))
            {
                MeshRenderer renderer = child.GetComponent<MeshRenderer>();
                if (renderer != null)
                {
                    Bounds bounds = renderer.bounds;
                    if (IsSmallerThanThreshold(bounds, threshold))
                    {
                        foundBuildings.Add(child.gameObject);
                    }
                }
            }

            // 再帰的に子孫を探索
            FindSmallBuildings(child, threshold, foundBuildings);
        }
    }

    static bool IsSmallerThanThreshold(Bounds bounds, float threshold)
    {
        return bounds.size.x < threshold && bounds.size.y < threshold && bounds.size.z < threshold;
    }
}
