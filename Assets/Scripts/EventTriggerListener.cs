using UnityEngine;
using UnityEngine.EventSystems;

namespace PlateauSamples.UrbanScape
{
    public class EventTriggerListener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public CameraController m_CameraController;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (m_CameraController != null)
            {
                m_CameraController.SetDraggingUI(true);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (m_CameraController != null)
            {
                m_CameraController.SetDraggingUI(false);
            }
        }
    }
}
