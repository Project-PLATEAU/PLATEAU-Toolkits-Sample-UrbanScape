using PlateauToolkit.Sandbox;
using UnityEngine;
using UnityEngine.UI;

namespace PlateauSamples.UrbanScape
{
    class SubCameraController : MonoBehaviour
    {
        [SerializeField] PlateauSandboxCameraManager m_CameraManager;
        [SerializeField] GameObject m_Buttons;
        [SerializeField] Button m_FirstPersonViewButton;
        [SerializeField] Button m_ThirdPersonViewButton;
        [SerializeField] Button m_ThirdPersonOrbitButton;
        [SerializeField] Button m_EndButton;

        void Awake()
        {
            m_FirstPersonViewButton.onClick.AddListener(() =>
            {
                m_CameraManager.SwitchCamera(PlateauSandboxCameraMode.FirstPersonView);
            });
            m_ThirdPersonViewButton.onClick.AddListener(() =>
            {
                m_CameraManager.SwitchCamera(PlateauSandboxCameraMode.ThirdPersonView);
            });
            m_ThirdPersonOrbitButton.onClick.AddListener(() =>
            {
                m_CameraManager.SwitchCamera(PlateauSandboxCameraMode.ThirdPersonOrbit);
            });
            m_EndButton.onClick.AddListener(() =>
            {
                m_CameraManager.SwitchCamera(PlateauSandboxCameraMode.None);
            });
        }

        void Update()
        {
            m_Buttons.SetActive(m_CameraManager.CurrentCameraMode != PlateauSandboxCameraMode.None);
        }
    }
}
