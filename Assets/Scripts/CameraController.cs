using UnityEngine;
using UnityEngine.EventSystems;

namespace PlateauSamples.UrbanScape
{
    public class CameraController : MonoBehaviour
    {
        public Transform m_Target;
        public float m_MoveSpeed = 5.0f;
        public float m_Sensitivity = 2.0f;
        public float m_OrbitDistance = 50.0f;
        public float m_MinVerticalAngle = 0f;
        public float m_MaxVerticalAngle = 80f;

        float m_RotationX = 0.0f;
        float m_RotationY = 0.0f;

        Quaternion m_InitialRotation;
        Vector3 m_InitialPosition;

        public Camera m_FixedCamera1;
        public Camera m_FixedCamera2;
        Camera m_MainCamera;

        bool m_IsDraggingUI;

        void Start()
        {
            m_MainCamera = GetComponent<Camera>();

            if (!m_Target)
            {
                Debug.LogError("CameraController requires a target Transform to orbit.");
                return;
            }

            Vector3 eulerAngles = transform.eulerAngles;
            m_RotationX = eulerAngles.y;
            m_RotationY = eulerAngles.x > 180 ? eulerAngles.x - 360 : eulerAngles.x;

            m_InitialRotation = transform.rotation;
            m_InitialPosition = transform.position;

            SetCameraPositionByTarget();
        }

        void Update()
        {
            if (EventSystem.current.IsPointerOverGameObject() || m_IsDraggingUI)
            {
                return;
            }

            HandleRotation();
        }

        void HandleRotation()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 eulerAngles = transform.eulerAngles;
                m_RotationX = eulerAngles.y;
                m_RotationY = eulerAngles.x > 180 ? eulerAngles.x - 360 : eulerAngles.x;
            }

            if (Input.GetMouseButton(0))
            {
                m_RotationX += Input.GetAxis("Mouse X") * m_Sensitivity;
                m_RotationY -= Input.GetAxis("Mouse Y") * m_Sensitivity;

                m_RotationY = Mathf.Clamp(m_RotationY, m_MinVerticalAngle, m_MaxVerticalAngle);

                Quaternion rotation = Quaternion.Euler(m_RotationY, m_RotationX, 0);
                Vector3 positionOffset = rotation * Vector3.back * m_OrbitDistance;
                transform.rotation = rotation;
                transform.position = m_Target.position + positionOffset;
            }
        }

        public void SetTargetPosition(Vector3 newPosition)
        {
            m_Target.position = newPosition;
            SetCameraPositionByTarget();
        }

        void SetCameraPositionByTarget()
        {
            Quaternion currentRotation = Quaternion.Euler(m_RotationY, m_RotationX, 0);
            Vector3 relativePosition = currentRotation * new Vector3(0.0f, 0.0f, -m_OrbitDistance);
            transform.position = m_Target.position + relativePosition;
        }

        public void ResetCamera()
        {
            if (!m_MainCamera.enabled)
            {
                SetToMainCamera();
            }

            transform.rotation = m_InitialRotation;
            transform.position = m_InitialPosition;

            m_RotationX = m_InitialRotation.eulerAngles.y;
            m_RotationY = m_InitialRotation.eulerAngles.x;
        }

        public void SetToFixedCamera1()
        {
            DisableAllCameras();
            m_FixedCamera1.enabled = true;
        }

        public void SetToFixedCamera2()
        {
            DisableAllCameras();
            m_FixedCamera2.enabled = true;
        }
        public void SetToMainCamera()
        {
            DisableAllCameras();
            m_MainCamera.enabled = true;
        }
        void DisableAllCameras()
        {
            m_MainCamera.enabled = false;
            m_FixedCamera1.enabled = false;
            m_FixedCamera2.enabled = false;
        }
        public void SetDraggingUI(bool dragging)
        {
            m_IsDraggingUI = dragging;
        }
    }
}