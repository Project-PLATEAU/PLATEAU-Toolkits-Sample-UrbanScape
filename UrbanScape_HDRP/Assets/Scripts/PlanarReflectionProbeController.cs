using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using PlateauToolkit.Rendering;

namespace PlateauSamples.UrbanScape
{
    [RequireComponent(typeof(PlanarReflectionProbe))]
    public class PlanarReflectionProbeController : MonoBehaviour
    {
        PlanarReflectionProbe m_PlanarReflectionProbe;
        [SerializeField] EnvironmentController m_EnvironmentController;
        float m_LastRainValue = -1;

        void Start()
        {
            m_PlanarReflectionProbe = GetComponent<PlanarReflectionProbe>();

            if (m_PlanarReflectionProbe == null || m_EnvironmentController == null)
            {
                return;
            }

            UpdateReflectionProbeWeight();
        }

        void Update()
        {
            if (m_EnvironmentController != null && m_EnvironmentController.m_Rain != m_LastRainValue)
            {
                UpdateReflectionProbeWeight();
            }
        }

        void UpdateReflectionProbeWeight()
        {
            m_PlanarReflectionProbe.weight = m_EnvironmentController.m_Rain;
            m_LastRainValue = m_EnvironmentController.m_Rain;
        }
    }
}
