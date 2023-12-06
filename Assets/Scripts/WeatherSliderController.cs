using UnityEngine;
using UnityEngine.UI;
using PlateauToolkit.Rendering;

namespace PlateauSamples.UrbanScape
{
    public class WeatherSliderController : MonoBehaviour
    {
        public Slider m_RainSlider;
        public Slider m_SnowSlider;
        public Slider m_CloudySlider;
        public EnvironmentController m_EnvironmentController;
        public CanvasGroup m_CanvasGroup;

        void Awake()
        {

            if (m_EnvironmentController == null)
            {
                Debug.LogError("EnvironmentController component is not found in the scene.");
                return;
            }
        }

        void Start()
        {
            m_RainSlider.onValueChanged.AddListener(HandleRainSliderChanged);
            m_CloudySlider.onValueChanged.AddListener(HandlecloudySliderChanged);
            m_SnowSlider.onValueChanged.AddListener(HandleSnowSliderChanged);
        }

        void HandleRainSliderChanged(float value)
        {
            if (m_CanvasGroup.alpha > 0)
            {
                m_EnvironmentController.m_Rain = value;
            }
        }

        void HandlecloudySliderChanged(float value)
        {
            if (m_CanvasGroup.alpha > 0)
            {
                m_EnvironmentController.m_Cloud = value;
            }
        }

        void HandleSnowSliderChanged(float value)
        {
            if (m_CanvasGroup.alpha > 0)
            {
                m_EnvironmentController.m_Snow = value;
            }
        }

        void OnDestroy()
        {
            m_RainSlider.onValueChanged.RemoveListener(HandleRainSliderChanged);
            m_CloudySlider.onValueChanged.RemoveListener(HandlecloudySliderChanged);
            m_SnowSlider.onValueChanged.RemoveListener(HandleSnowSliderChanged);
        }
    }
}
