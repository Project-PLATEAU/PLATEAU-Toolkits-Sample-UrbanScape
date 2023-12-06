using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class MeshRendererSelector : EditorWindow
{
    [MenuItem("Tools/Mesh Renderer Selector")]
    public static void ShowWindow()
    {
        GetWindow<MeshRendererSelector>("Mesh Renderer Selector");
    }

    void OnGUI()
    {
        if (GUILayout.Button("Select Active MeshRenderers with 'bldg_' Prefix"))
        {
            SelectActiveMeshRenderersWithPrefix();
        }
    }

    void SelectActiveMeshRenderersWithPrefix()
    {
        if (Selection.activeTransform == null)
        {
            Debug.LogWarning("No object selected in the hierarchy.");
            return;
        }

        List<GameObject> selectThese = new List<GameObject>();
        RecursiveFindMeshRenderersWithPrefix(Selection.activeTransform, selectThese, "bldg_");

        if (selectThese.Count > 0)
        {
            Selection.objects = selectThese.ToArray();
        }
        else
        {
            Debug.Log("No active MeshRenderers with 'bldg_' prefix found below the selected object.");
        }
    }

    void RecursiveFindMeshRenderersWithPrefix(Transform parent, List<GameObject> listToFill, string prefix)
    {
        foreach (Transform child in parent)
        {
            MeshRenderer renderer = child.GetComponent<MeshRenderer>();
            if (renderer != null && renderer.enabled && child.name.StartsWith(prefix))
            {
                listToFill.Add(child.gameObject);
            }

            // Recurse into children
            RecursiveFindMeshRenderersWithPrefix(child, listToFill, prefix);
        }
    }
}
