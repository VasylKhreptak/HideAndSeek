using System.Collections;
using CBA.Events.Core;
using CBA.Extensions;
using Extensions;
using UnityEngine;
using UnityEngine.AI;
using Transform = UnityEngine.Transform;
using Vector3 = UnityEngine.Vector3;

namespace Gameplay.Bots.HideBot.Movement
{
    public class HidePlayerBotMovement : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Transform _seekTransform;

        [Header("Default Target Transforms")]
        [SerializeField] private Transform[] _transforms;

        [Header("Default Movement Preferences")]
        [SerializeField] private float _minChangeTargetDelay;
        [SerializeField] private float _maxChangeTargetDelay;

        [Header("Escape Preferences")]
        [SerializeField] private float _minEscapeTargetSearchDelay;
        [SerializeField] private float _maxEscapeTargetSearchDelay;

        [Header("Events")]
        [SerializeField] private MonoEvent _seekEnteredEvent;
        [SerializeField] private MonoEvent _seekExitedEvent;

        private float ChangeTargetDelay => Random.Range(_minChangeTargetDelay, _maxChangeTargetDelay);
        private float EscapeTargetSearchDelay => Random.Range(_minEscapeTargetSearchDelay, _maxEscapeTargetSearchDelay);

        private Vector3 TargetPosition => _transforms.Random().position;

        private Coroutine _movementCoroutine;
        private Coroutine _escapingCoroutine;

        #region MonoBehaviour

        private void OnValidate()
        {
            _agent ??= GetComponent<NavMeshAgent>();
        }

        private void OnEnable()
        {
            StartRandomMovement();

            _seekEnteredEvent.onMonoCall += OnSeekEntered;
            _seekExitedEvent.onMonoCall += OnSeekExited;
        }

        private void OnDisable()
        {
            StopRandomMovement();

            _seekEnteredEvent.onMonoCall -= OnSeekEntered;
            _seekExitedEvent.onMonoCall -= OnSeekExited;
        }

        #endregion

        private void OnSeekEntered()
        {
            StopRandomMovement();
            StartEscaping();
        
            Debug.Log("Seek Entered");
        }

        private void OnSeekExited()
        {
            StartRandomMovement();
            StopEscaping();
        
            Debug.Log("Seek Exited");
        }

        private void StartRandomMovement()
        {
            if (_movementCoroutine == null)
            {
                _movementCoroutine = StartCoroutine(RandomMovementRoutine());
            }
        }

        private void StopRandomMovement()
        {
            if (_movementCoroutine != null)
            {
                StopCoroutine(_movementCoroutine);

                _movementCoroutine = null;
            }
        }

        private IEnumerator RandomMovementRoutine()
        {
            while (true)
            {
                SelectRandomTarget();

                yield return new WaitForSeconds(ChangeTargetDelay);
            }
        }

        private void SelectRandomTarget()
        {
            _agent.SetDestination(TargetPosition);
        }

        private void StartEscaping()
        {
            if (_escapingCoroutine == null)
            {
                _escapingCoroutine = StartCoroutine(EscapeRoutine());
            }
        }

        private void StopEscaping()
        {
            if (_escapingCoroutine != null)
            {
                StopCoroutine(_escapingCoroutine);

                _escapingCoroutine = null;
            }
        }

        private IEnumerator EscapeRoutine()
        {
            while (true)
            {
                _agent.SetDestination(GetEscapePosition());

                yield return new WaitForSeconds(EscapeTargetSearchDelay);
            }
        }

        private Vector3 GetEscapePosition()
        {
            return _seekTransform.FarthestTransform(_transforms).position;
        }
    }
}
