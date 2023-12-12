using PlateauToolkit.Sandbox;
using UnityEngine.Rendering;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace PlateauSamples.UrbanScape
{
    [RequireComponent(typeof(PlateauSandboxTrackMovement))]
    public class TrackPositionBasedFader : MonoBehaviour
    {
        [SerializeField] float m_FadeInStart = 0.2f;
        [SerializeField] float m_FadeOutStart = 0.8f;

        PlateauSandboxTrackMovement m_TrackMovement;
        Material[][] m_Materials;
        MeshRenderer[] m_MeshRenderers;
        DecalProjector[] m_DecalProjectors;

        void Start()
        {
            m_TrackMovement = GetComponent<PlateauSandboxTrackMovement>();
            if (m_TrackMovement == null)
            {
                return;
            }

            m_MeshRenderers = GetComponentsInChildren<MeshRenderer>();
            m_DecalProjectors = GetComponentsInChildren<DecalProjector>();

            m_Materials = new Material[m_MeshRenderers.Length][];
            for (int i = 0; i < m_MeshRenderers.Length; i++)
            {
                m_Materials[i] = m_MeshRenderers[i].materials;
            }
        }

        void Update()
        {
            if (m_Materials == null || m_TrackMovement == null)
            {
                return;
            }

            float t = m_TrackMovement.SplineContainerT;
            float opacity = CalculateOpacity(t);
            float decalOpacity = CalculateDecalOpacity(t);
            bool shouldCastShadows = opacity >= 1f;

            for (int i = 0; i < m_MeshRenderers.Length; i++)
            {
                m_MeshRenderers[i].shadowCastingMode = shouldCastShadows ? ShadowCastingMode.On : ShadowCastingMode.Off;
                foreach (Material material in m_Materials[i])
                {
                    if (material.HasProperty("_Opacity"))
                    {
                        material.SetFloat("_Opacity", opacity);
                    }
                    else if (material.HasProperty("_BaseColor"))
                    {
                        Color color = material.GetColor("_BaseColor");
                        color.a = opacity * 0.5f;
                        material.SetColor("_BaseColor", color);
                    }
                }
            }
            foreach (DecalProjector decal in m_DecalProjectors)
            {
                decal.fadeFactor = decalOpacity;
            }
        }

        float CalculateOpacity(float t)
        {
            if (t < m_FadeInStart)
            {
                return t / m_FadeInStart;
            }
            else
            {
                return t > m_FadeOutStart ? (1 - t) / (1 - m_FadeOutStart) : 1;
            }
        }

        float CalculateDecalOpacity(float t)
        {
            float decalFadeInStart = 0.4f;
            float decalFadeOutStart = 0.4f;

            if (t < decalFadeInStart)
            {
                return t / decalFadeInStart;
            }
            else if (t > decalFadeOutStart)
            {
                return Mathf.Clamp01((1 - t) / (1 - decalFadeOutStart));
            }
            return 1.0f;
        }
    }
}
