using PlateauToolkit.Rendering;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace PlateauSamples.UrbanScape
{
    [RequireComponent(typeof(ReflectionProbe))]
    public class ReflectionProbeController : MonoBehaviour
    {
        HDProbe m_ReflectionProbe;
        [SerializeField] EnvironmentController m_EnvironmentController;
        [SerializeField] Gradient m_RainReflectivityGradient;
        [SerializeField] Camera[] m_TargetCameras;
        float m_LastRainValue = -1;

        void Start()
        {
            m_ReflectionProbe = GetComponent<HDProbe>();

            if (m_ReflectionProbe == null || m_EnvironmentController == null || m_RainReflectivityGradient == null)
            {
                return;
            }

            UpdateReflectionProbe();
        }

        void Update()
        {
            if (m_EnvironmentController != null && m_EnvironmentController.m_Rain != m_LastRainValue)
            {
                UpdateReflectionProbe();
            }
        }

        void UpdateReflectionProbe()
        {
            bool isAnyCameraActive = false;
            foreach (Camera camera in m_TargetCameras)
            {
                if (camera != null && camera.enabled)
                {
                    isAnyCameraActive = true;
                    break;
                }
            }

            if (!isAnyCameraActive)
            {
                m_ReflectionProbe.weight = 0;
            }
            else
            {
                float rainValue = m_EnvironmentController.m_Rain;
                float gradientWeight = m_RainReflectivityGradient.Evaluate(rainValue).r;
                m_ReflectionProbe.weight = gradientWeight;
            }

            m_LastRainValue = m_EnvironmentController.m_Rain;
        }
    }
}
