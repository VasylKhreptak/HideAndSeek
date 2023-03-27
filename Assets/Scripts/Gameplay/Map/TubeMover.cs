using System.Collections;
using CBA.Events.Core;
using NaughtyAttributes;
using PathCreation;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Map
{
    public class TubeMover : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _transform;
        [SerializeField] private TubeMover _anotherTube;
        [SerializeField] private PathCreator _pathCreator;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private Transform _cameraTransform;

        [Header("Preferences")]
        [SerializeField] private float _speed = 5f;
        [SerializeField] private Vector3 _targetPlayerPosition;
        [SerializeField] private Vector3 _startPosition;
        [SerializeField] private Vector3 _startRotation;
        [FormerlySerializedAs("_playerDirection")]
        [SerializeField] private Vector3 _targetPlayerDirection;

        [Header("Events")]
        [SerializeField] private MonoEvent _startMovementEvent;

        private Coroutine _movementCoroutine;

        private float _travelledDistance;

        private Vector3 _previousCameraLocalPosition;
        private Quaternion _previousCameraLocalRotation;

        private Vector3 _previousTubePosition;
        private Quaternion _previousTubeRotation;

        #region MonoBehaviour

        private void OnValidate()
        {
            _transform ??= GetComponent<Transform>();
            _cameraTransform ??= Camera.main.transform;

            if (_playerTransform != null)
            {
                _cameraTransform = _playerTransform.GetComponentInChildren<Camera>()?.transform;
            }
        }

        private void Awake()
        {
            _previousTubePosition = _transform.position;
            _previousTubeRotation = _transform.rotation;
        }

        private void OnEnable()
        {
            _startMovementEvent.onMonoCall += StartMovementInAnotherTube;
        }

        private void OnDisable()
        {
            _startMovementEvent.onMonoCall -= StartMovementInAnotherTube;
        }

        #endregion

        private void StartMovementInAnotherTube()
        {
            _anotherTube.StartMovement();
        }

        public void StartMovement()
        {
            if (_movementCoroutine == null)
            {
                _playerTransform.gameObject.SetActive(false);
                _previousCameraLocalPosition = _cameraTransform.localPosition;
                _previousCameraLocalRotation = _cameraTransform.localRotation;
                _cameraTransform.SetParent(null);
                _transform.position = _startPosition;
                _transform.rotation = Quaternion.Euler(_startRotation);

                _movementCoroutine = StartCoroutine(MovementRoutine());
            }
        }

        private void StopMovement()
        {
            if (_movementCoroutine != null)
            {
                StopCoroutine(_movementCoroutine);

                _movementCoroutine = null;

                _travelledDistance = 0f;

                _playerTransform.gameObject.SetActive(true);
                _playerTransform.position = _targetPlayerPosition;
                _playerTransform.forward = _targetPlayerDirection;
                _cameraTransform.SetParent(_playerTransform);
                _cameraTransform.localPosition = _previousCameraLocalPosition;
                _cameraTransform.localRotation = _previousCameraLocalRotation;
                _transform.position = _previousTubePosition;
                _transform.rotation = _previousTubeRotation;
            }
        }

        private IEnumerator MovementRoutine()
        {
            while (true)
            {
                Move();

                yield return null;
            }
        }

        private void Move()
        {
            _travelledDistance += _speed * Time.deltaTime;
            _travelledDistance = Mathf.Clamp(_travelledDistance, 0f, _pathCreator.path.length);
            _cameraTransform.position = _pathCreator.path.GetPointAtDistance(_travelledDistance, EndOfPathInstruction.Stop);
            _cameraTransform.forward = _pathCreator.path.GetDirectionAtDistance(_travelledDistance, EndOfPathInstruction.Stop);

            if (Mathf.Approximately(_travelledDistance, _pathCreator.path.length))
            {
                StopMovement();
            }
        }

        [Button("Update Start Position")]
        private void UpdateStartPosition()
        {
            _startPosition = _transform.position;
        }

        [Button("Update Start Rotation")]
        private void UpdateStartRotation()
        {
            _startRotation = _transform.rotation.eulerAngles;
        }
    }
}
