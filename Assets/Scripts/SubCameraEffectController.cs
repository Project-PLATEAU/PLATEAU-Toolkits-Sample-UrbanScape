using UnityEngine;
using UnityEngine.Rendering;
using PlateauToolkit.Rendering;

namespace PlateauSamples.UrbanScape
{
    public class SubCameraEffectController : MonoBehaviour
    {
        [SerializeField] Camera m_NearCamera;
        [SerializeField] Camera m_SubCamera;
        [SerializeField] Volume m_SubCameraVolume;
        [SerializeField] EnvironmentController m_EnvironmentController;

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
        }

        void UpdateEnvironmentController(bool isActive)
        {
            if (m_EnvironmentController != null)
            {
                m_EnvironmentController.m_OpacityDistMax = isActive ? 1 : 90;
            }
        }
    }
}
