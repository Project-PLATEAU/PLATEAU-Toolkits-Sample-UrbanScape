using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class TextureResizerWindow : EditorWindow
{
    string m_ThresholdInput = "2048";

    [MenuItem("Tools/Texture Resizer Window")]
    public static void ShowWindow()
    {
        GetWindow<TextureResizerWindow>("Texture Resizer");
    }

    void OnGUI()
    {
        GUILayout.Label("Resize Settings", EditorStyles.boldLabel);
        m_ThresholdInput = EditorGUILayout.TextField("Resize Threshold", m_ThresholdInput);

        if (GUILayout.Button("Apply"))
        {
            TextureResizer.ResizeTextures(m_ThresholdInput);
        }
    }
}

public class TextureResizer
{
    public static void ResizeTextures(string thresholdInput)
    {
        GameObject[] selectedGameObjects = Selection.gameObjects;

        if (selectedGameObjects.Length == 0)
        {
            Debug.LogError("No GameObjects selected.");
            return;
        }

        int scaleOption = EditorUtility.DisplayDialogComplex("Resize Textures", "Choose the scale to resize the textures to:", "1/2", "1/4", "Cancel");

        if (scaleOption == 2)
        {
            return; // Cancel
        }

        int scaleFactor = scaleOption == 0 ? 2 : 4;

        int resizeThreshold;
        if (!int.TryParse(thresholdInput, out resizeThreshold))
        {
            Debug.LogError("Invalid threshold value entered.");
            return;
        }

        List<Texture2D> allTextures = new List<Texture2D>();
        foreach (GameObject selectedGameObject in selectedGameObjects)
        {
            MeshRenderer meshRenderer = selectedGameObject.GetComponent<MeshRenderer>();

            if (meshRenderer == null)
            {
                Debug.LogError("The selected GameObject does not have a MeshRenderer: " + selectedGameObject.name);
                continue;
            }

            Material[] materials = meshRenderer.sharedMaterials;

            foreach (Material material in materials)
            {
                Texture2D texture = material.GetTexture("_BaseColorMap") as Texture2D;
                if (texture != null)
                {
                    allTextures.Add(texture);
                }
            }
        }

        List<Texture2D> uniqueTextures = new List<Texture2D>();
        foreach (Texture2D texture in allTextures)
        {
            if (!uniqueTextures.Contains(texture))
            {
                uniqueTextures.Add(texture);
            }
        }

        Dictionary<Texture2D, Texture2D> resizedTextures = new Dictionary<Texture2D, Texture2D>();
        foreach (Texture2D uniqueTexture in uniqueTextures)
        {
            int resizedWidth = uniqueTexture.width / scaleFactor;
            int resizedHeight = uniqueTexture.height / scaleFactor;

            if (resizedWidth < resizeThreshold && resizedHeight < resizeThreshold)
            {
                continue;
            }

            Texture2D resizedTexture = Resize(uniqueTexture, resizedWidth, resizedHeight);
            resizedTextures.Add(uniqueTexture, resizedTexture);
        }

        foreach (GameObject selectedGameObject in selectedGameObjects)
        {
            MeshRenderer meshRenderer = selectedGameObject.GetComponent<MeshRenderer>();

            if (meshRenderer == null)
            {
                continue;
            }

            Material[] materials = meshRenderer.sharedMaterials;

            foreach (Material material in materials)
            {
                Texture2D originalTexture = material.GetTexture("_BaseColorMap") as Texture2D;
                if (originalTexture != null)
                {
                    Texture2D resizedTexture;
                    if (resizedTextures.TryGetValue(originalTexture, out resizedTexture))
                    {
                        material.SetTexture("_BaseColorMap", resizedTexture);
                    }
                }
            }

            Debug.Log("Textures resized successfully for: " + selectedGameObject.name);
        }
    }

    static Texture2D Resize(Texture2D texture2D, int targetX, int targetY)
    {
        RenderTexture rt = new RenderTexture(targetX, targetY, 24);
        RenderTexture.active = rt;
        Graphics.Blit(texture2D, rt);
        Texture2D result = new Texture2D(targetX, targetY, TextureFormat.ARGB32, true);
        result.ReadPixels(new Rect(0, 0, targetX, targetY), 0, 0);
        result.Compress(true);
        result.Apply(false);

        return result;
    }
}
