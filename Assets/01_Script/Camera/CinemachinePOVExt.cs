using Cinemachine;
using UnityEngine;

namespace flat_land.camera
{
    public class CinemachinePOVExt : CinemachineExtension
    {
        Vector3 startingRotation;

        Vector2 mouseDelta;
        [SerializeField] private float horizontalSpeed;
        [SerializeField] private float verticalSpeed = 10f;
        [SerializeField] private float clampAngle = 80f;

        public void SetMousePosition(Vector2 mousePosition, float horizontalSpeed)
        {
            this.mouseDelta = mousePosition;
            this.horizontalSpeed = horizontalSpeed;
        }

        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (vcam.Follow)
            {
                if (stage == CinemachineCore.Stage.Aim)
                {
                    if (startingRotation == null) startingRotation = transform.localEulerAngles;

                    startingRotation.y += mouseDelta.y * Time.deltaTime * horizontalSpeed;
                    startingRotation.x += mouseDelta.x * Time.deltaTime * verticalSpeed;

                    startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);

                    state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);
                    mouseDelta = Vector3.zero;
                }
            }
        }
    }
}

