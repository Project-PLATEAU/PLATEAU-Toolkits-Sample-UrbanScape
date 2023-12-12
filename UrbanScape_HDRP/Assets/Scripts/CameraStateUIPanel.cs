using UnityEngine;

namespace PlateauSamples.UrbanScape
{
    [RequireComponent(typeof(CanvasGroup))]
    public class CameraStateUIPanel : MonoBehaviour
    {
        [SerializeField] Camera m_TargetCamera;
        CanvasGroup m_CanvasGroup;

        void Start()
        {
            m_CanvasGroup = GetComponent<CanvasGroup>();
            if (m_CanvasGroup == null)
            {
                return;
            }
        }

        void Update()
        {
            if (m_CanvasGroup != null)
            {
                UpdatePanelVisibility();
            }
        }

        void UpdatePanelVisibility()
        {
            if (m_TargetCamera != null && m_TargetCamera.isActiveAndEnabled)
            {
                m_CanvasGroup.alpha = 1;
            }
            else
            {
                m_CanvasGroup.alpha = 0;
            }
        }
    }
}
