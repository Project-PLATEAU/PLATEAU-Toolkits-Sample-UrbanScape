using UnityEngine;
using PlateauToolkit.Rendering;
using System.Collections.Generic;

namespace PlateauSamples.UrbanScape
{
    public class NightLightController : MonoBehaviour
    {
        List<Light> m_SceneLights;
        Dictionary<Light, float> m_OriginalIntensities;
        EnvironmentController m_EnvironmentController;

        void Start()
        {
            m_SceneLights = new List<Light>();
            m_OriginalIntensities = new Dictionary<Light, float>();

            foreach (var light in FindObjectsOfType<Light>())
            {
                if (light.type != LightType.Directional)
                {
                    m_SceneLights.Add(light);
                    m_OriginalIntensities[light] = light.intensity;
                }
            }

            m_EnvironmentController = FindObjectOfType<EnvironmentController>();
            if (m_EnvironmentController == null)
            {
                Debug.LogError("EnvironmentController not found in the scene.");
                return;
            }
        }

        void Update()
        {
            if (m_EnvironmentController != null)
            {
                UpdateLights();
            }
        }

        void UpdateLights()
        {
            foreach (var light in m_SceneLights)
            {
                light.intensity = m_OriginalIntensities[light] * m_EnvironmentController.IsNight;
            }
        }
    }
}
