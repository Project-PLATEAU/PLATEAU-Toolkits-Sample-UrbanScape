using UnityEngine;
using UnityEngine.Rendering;
using PlateauToolkit.Rendering;
using PlateauToolkit.Sandbox;

namespace PlateauSamples.UrbanScape
{
    public class SubCameraEffectController : MonoBehaviour
    {
        [SerializeField] Camera m_NearCamera;
        [SerializeField] Camera m_SubCamera;
        [SerializeField] Volume m_SubCameraVolume;
        [SerializeField] Volume m_SubCameraThirdPersonOrbitVolume;
        [SerializeField] PlateauSandboxCameraManager m_CameraManager;
        EnvironmentController m_EnvironmentController;

        void Start()
        {
            m_EnvironmentController = FindObjectOfType<EnvironmentController>();
        }

        void Update()
        {
            bool isAnyCameraActive = IsNearCameraActive();
            UpdateEnvironmentController(isAnyCameraActive);
        }

        bool IsNearCameraActive()
        {
            return (m_SubCamera != null && m_SubCamera.enabled) || (m_NearCamera != null && m_NearCamera.enabled);
        }

        void UpdateEnvironmentController(bool isActive)
        {
            if (m_EnvironmentController != null)
            {
                m_EnvironmentController.m_OpacityDistMax = isActive ? 2 : 90;
            }
        }
    }
}
