using UnityEngine;
using UnityEngine.UI;

namespace PlateauSamples.UrbanScape
{
    public class ButtonController : MonoBehaviour
    {
        [SerializeField] Button m_HomeButton;
        [SerializeField] Button m_Camera1Button;
        [SerializeField] Button m_Camera2Button;
        [SerializeField] Button m_BackButton;
        [SerializeField] CameraController m_CameraController;

        void Start()
        {
            m_HomeButton.onClick.AddListener(OnHomeButtonClicked);
            m_Camera1Button.onClick.AddListener(OnCamera1ButtonClicked);
            m_Camera2Button.onClick.AddListener(OnCamera2ButtonClicked);
            m_BackButton.onClick.AddListener(OnBackButtonClicked);
        }

        void OnHomeButtonClicked()
        {
            if (m_CameraController != null)
            {
                m_CameraController.ResetCamera();
            }
        }

        void OnCamera1ButtonClicked()
        {
            m_CameraController.SetToFixedCamera1();
        }

        void OnCamera2ButtonClicked()
        {
            m_CameraController.SetToFixedCamera2();
        }

        void OnBackButtonClicked()
        {

        }
    }
}
