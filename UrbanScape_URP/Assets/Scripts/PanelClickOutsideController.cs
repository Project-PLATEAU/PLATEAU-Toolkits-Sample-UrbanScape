using UnityEngine;
using UnityEngine.EventSystems;

namespace PlateauSamples.UrbanScape
{
    [RequireComponent(typeof(CanvasGroup))]
    public class PanelClickOutsideController : MonoBehaviour
    {
        [SerializeField] CanvasGroup m_PanelCanvasGroup;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    if (m_PanelCanvasGroup.alpha > 0)
                    {
                        m_PanelCanvasGroup.alpha = 0;
                        m_PanelCanvasGroup.blocksRaycasts = false;
                    }
                }
            }
        }
    }
}
