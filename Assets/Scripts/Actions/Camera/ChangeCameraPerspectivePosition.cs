using Gameplay;
using UnityEngine;
using Action = CBA.Actions.Core.Action;

namespace Actions.Camera
{
    public class ChangeCameraPerspectivePosition : Action
    {
        [Header("References")]
        [SerializeField] private Transform _cameraHeightTransform;
        [SerializeField] private Transform _cameraTransform;

        [Header("Preferences")]
        [SerializeField] private int _raycasts = 10;
        [SerializeField] private float _offset;
        [SerializeField] private float _maxScanDistance;
        [SerializeField] private LayerMask _obstacleMask;

        #region MonoBehaviour

        private void OnValidate()
        {
            _cameraTransform ??= UnityEngine.Camera.main.transform;
        }

        #endregion

        private void OnDrawGizmos()
        {
            Vector3 cameraPosition = CameraViewportFinder.FindViewport(_cameraHeightTransform.position, _raycasts,
                _offset, _maxScanDistance, _obstacleMask);

            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(cameraPosition, 0.5f);
            Gizmos.color = CBA.Extensions.Color.WithAlpha(Color.green, 0.3f);
            Gizmos.DrawSphere(_cameraHeightTransform.position, _maxScanDistance);
        }
        public override void Do()
        {
            _cameraTransform.position = CameraViewportFinder.FindViewport(_cameraHeightTransform.position, _raycasts,
                _offset, _maxScanDistance, _obstacleMask);
        }
    }
}
