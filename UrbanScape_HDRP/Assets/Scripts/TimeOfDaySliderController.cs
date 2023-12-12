using UnityEngine;
using UnityEngine.UI;
using PlateauToolkit.Rendering;

namespace PlateauSamples.UrbanScape
{
    public class TimeOfDaySliderController : MonoBehaviour
    {
        [SerializeField] Slider m_Slider;
        EnvironmentController m_EnvironmentController;

        void Awake()
        {
            if (m_Slider == null)
            {
                return;
            }

            m_EnvironmentController = FindObjectOfType<EnvironmentController>();
            if (m_EnvironmentController == null)
            {
                return;
            }

            m_Slider.onValueChanged.AddListener(HandleSliderValueChanged);
        }

        public void HandleSliderValueChanged(float value)
        {
            m_EnvironmentController.m_TimeOfDay = value;
        }

        void OnDestroy()
        {
            if (m_Slider != null)
            {
                m_Slider.onValueChanged.RemoveListener(HandleSliderValueChanged);
            }
        }
    }
}
