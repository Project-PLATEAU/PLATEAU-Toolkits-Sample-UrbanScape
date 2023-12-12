using UnityEditor;
using UnityEngine;

public class FixMaterials
{
    [MenuItem("MSQ/FIX_MATERIALS")]
    public static void UpdateOldProperties()
    {
        foreach (Object obj in Selection.GetFiltered(typeof(MeshRenderer), SelectionMode.DeepAssets))
        {
            MeshRenderer meshRenderer = obj as MeshRenderer;
            if (meshRenderer != null)
            {
                foreach (Material mat in meshRenderer.sharedMaterials)
                {
                    if (mat != null && mat.name != "PlateauDefaultBuilding")
                    {
                        ReplaceShader(mat, "Weather/URP Building Shader");
                        CopyTextureProperty(mat);
                    }
                }
            }
        }
    }

    static void ReplaceShader(Material mat, string shaderName)
    {
        Shader newShader = Shader.Find(shaderName);
        if (newShader != null)
        {
            mat.shader = newShader;
        }
        else
        {
            Debug.LogWarning("Shader not found: " + shaderName);
        }
    }
    static void CopyTextureProperty(Material mat)
    {
        var so = new SerializedObject(mat);
        SerializedProperty texEnvs = so.FindProperty("m_SavedProperties").FindPropertyRelative("m_TexEnvs");

        if (texEnvs.arraySize < 2)
        {
            Debug.LogWarning("Not enough elements in TexEnvs array for material: " + mat.name);
            return;
        }

        SerializedProperty firstTexProp = texEnvs.GetArrayElementAtIndex(2).FindPropertyRelative("second").FindPropertyRelative("m_Texture");
        Debug.Log(firstTexProp.objectReferenceValue);

        SerializedProperty secondTexProp = texEnvs.GetArrayElementAtIndex(1).FindPropertyRelative("second").FindPropertyRelative("m_Texture");
        Debug.Log(secondTexProp.objectReferenceValue);

        if (firstTexProp == null || secondTexProp == null)
        {
            Debug.LogWarning("Could not find texture properties for material: " + mat.name);
            return;
        }

        firstTexProp.objectReferenceValue = secondTexProp.objectReferenceValue;
        so.ApplyModifiedProperties();

        Debug.Log("Texture properties updated for material: " + mat.name);
    }
}
