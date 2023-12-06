using PlateauToolkit.Rendering;
using UnityEngine;

namespace PlateauSamples.UrbanScape
{
    [RequireComponent(typeof(EnvironmentController))]
    public class DayTimeController : MonoBehaviour
    {
        public bool m_DayTimeIsDynamic;
        public EnvironmentController m_EnvironmentController;
        public float m_Speed = 0.1f;

        readonly float m_WeatherChangeTime = 20f;
        float m_CurrentTime = 0f;
        int m_WeatherState = 0;

        readonly float m_TransitionDuration = 5f; // Duration of the weather transition
        float m_TransitionTime = 0f; // Timer for the current transition

        float m_TargetRain = 0f;
        float m_TargetSnow = 0f;

        void ToggleState()
        {
            m_WeatherState = (m_WeatherState + 1) % 3;
            m_TransitionTime = m_TransitionDuration; // Reset the transition timer

            // Set the target weather values
            switch (m_WeatherState)
            {
                case 0: // Clear
                    m_TargetRain = 0f;
                    m_TargetSnow = 0f;
                    break;
                case 1: // Rain
                    m_TargetRain = 1f;
                    m_TargetSnow = 0f;
                    break;
                case 2: // Snow
                    m_TargetRain = 0f;
                    m_TargetSnow = 1f;
                    break;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            m_EnvironmentController = GetComponent<EnvironmentController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (m_DayTimeIsDynamic)
            {
                m_EnvironmentController.m_TimeOfDay += m_Speed * Time.deltaTime;
                m_EnvironmentController.m_TimeOfDay %= 1f; // Ensure time of day wraps around
            }

            if (m_CurrentTime < m_WeatherChangeTime)
            {
                m_CurrentTime += Time.deltaTime;
            }
            else
            {
                m_CurrentTime = 0f;
                ToggleState();
            }

            // Handle the weather transition
            if (m_TransitionTime > 0f)
            {
                m_TransitionTime -= Time.deltaTime;
                float progress = 1f - (m_TransitionTime / m_TransitionDuration);

                // Clamp the progress to be between 0 and 1
                progress = Mathf.Clamp01(progress);

                // Use Mathf.Lerp to smoothly transition towards the target weather values
                m_EnvironmentController.m_Rain = Mathf.Lerp(m_EnvironmentController.m_Rain, m_TargetRain, progress);
                m_EnvironmentController.m_Snow = Mathf.Lerp(m_EnvironmentController.m_Snow, m_TargetSnow, progress);

                // If the progress is essentially complete, clamp the values to the target to avoid tiny numerical errors.
                if (progress >= 1f)
                {
                    m_EnvironmentController.m_Rain = m_TargetRain;
                    m_EnvironmentController.m_Snow = m_TargetSnow;
                }
            }
        }
    }
}