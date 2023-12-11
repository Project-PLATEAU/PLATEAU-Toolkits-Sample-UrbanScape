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
        [SerializeField] EnvironmentController m_EnvironmentController;
        [SerializeField] PlateauSandboxCameraManager m_CameraManager;

        void Update()
        {
            bool isAnyCameraActive = IsNearCameraActive();
            UpdateVolumeActivation(isAnyCameraActive);
            UpdateEnvironmentController(isAnyCameraActive);
        }

        bool IsNearCameraActive()
        {
            return (m_SubCamera != null && m_SubCamera.enabled) || (m_NearCamera != null && m_NearCamera.enabled);
        }

        void UpdateVolumeActivation(bool isActive)
        {
            if (m_SubCameraVolume != null)
            {
                m_SubCameraVolume.enabled = isActive;
            }

            if (m_SubCameraVolume != null)
            {
                if (m_SubCameraThirdPersonOrbitVolume != null)
                {
                    m_SubCameraThirdPersonOrbitVolume.enabled = m_CameraManager.CurrentCameraMode == PlateauSandboxCameraMode.ThirdPersonOrbit;

                    if (m_EnvironmentController != null)
                    {
                        m_SubCameraThirdPersonOrbitVolume.weight = m_EnvironmentController.m_Rain;
                    }
                }
            }
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
