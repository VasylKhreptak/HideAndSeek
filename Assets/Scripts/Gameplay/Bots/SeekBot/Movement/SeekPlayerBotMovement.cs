using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.Bots.SeekBot.Movement
{
    public class SeekPlayerBotMovement : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _transform;
        [SerializeField] private NavMeshAgent _agent;

        [Header("Preferences")]
        [SerializeField] private float _targetSearchDelay;
        [SerializeField] private float _repathDelay;
        [Space]
        [SerializeField] private List<Transform> _targets;

        private Transform _currentTarget;

        private Vector3 Destination => _currentTarget.position;

        private Coroutine _moveCoroutine;
        private Coroutine _targetSearchCoroutine;

        #region MonoBehaviuor

        private void OnValidate()
        {
            _transform ??= GetComponent<Transform>();
            _agent ??= GetComponent<NavMeshAgent>();
        }

        private void OnEnable()
        {
            StartSearchingTarget();
            StartMovement();
        }

        private void OnDisable()
        {
            Stop();
        }

        #endregion

        private void Stop()
        {
            StopSearchingTarget();
            StopMovement();
        }

        public void RemoveTarget(Transform target)
        {
            _targets.Remove(target);

            UpdateTarget();
        }

        private void StartMovement()
        {
            if (_moveCoroutine == null)
            {
                _moveCoroutine = StartCoroutine(MovementRoutine());
            }
        }

        private void StopMovement()
        {
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);

                _moveCoroutine = null;

                _agent.isStopped = true;
            }
        }

        private IEnumerator MovementRoutine()
        {
            while (true)
            {
                if (_targets.Count > 0)
                {
                    _agent.SetDestination(Destination);
                }
                else
                {
                    Stop();
                }

                yield return new WaitForSeconds(_repathDelay);
            }
        }

        private void StartSearchingTarget()
        {
            if (_targetSearchCoroutine == null)
            {
                _targetSearchCoroutine = StartCoroutine(SearchTargetRoutine());
            }
        }

        private void StopSearchingTarget()
        {
            if (_targetSearchCoroutine != null)
            {
                StopCoroutine(_targetSearchCoroutine);

                _targetSearchCoroutine = null;
            }
        }

        private IEnumerator SearchTargetRoutine()
        {
            while (true)
            {
                UpdateTarget();

                yield return new WaitForSeconds(_targetSearchDelay);
            }
        }

        private void UpdateTarget()
        {
            _currentTarget = _transform.ClosestTransform(_targets.ToArray());
        }
    }
}
