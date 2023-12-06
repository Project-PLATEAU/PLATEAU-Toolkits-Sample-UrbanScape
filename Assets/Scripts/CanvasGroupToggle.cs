using UnityEngine;

namespace PlateauSamples.UrbanScape
{
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasGroupToggle : MonoBehaviour
    {
        [SerializeField] CanvasGroup m_CanvasGroup;

        void Awake()
        {
            m_CanvasGroup = GetComponent<CanvasGroup>();
        }

        public void ToggleAlpha()
        {
            m_CanvasGroup.alpha = m_CanvasGroup.alpha > 0 ? 0 : 1;
            m_CanvasGroup.blocksRaycasts = m_CanvasGroup.alpha > 0;
        }
    }
}
