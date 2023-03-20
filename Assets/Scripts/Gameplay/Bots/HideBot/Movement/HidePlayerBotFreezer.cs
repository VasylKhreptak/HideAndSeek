using Graphics.Animations;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.Bots.HideBot.Movement
{
    public class HidePlayerBotFreezer : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private HidePlayerBotMovement _movement;
        [SerializeField] private Animator _animator;
        [SerializeField] private MovementAnimation _movementAnimation;

        #region MonoBehaviour

        private void OnValidate()
        {
            _agent ??= GetComponent<NavMeshAgent>();
            _movement ??= GetComponent<HidePlayerBotMovement>();
            _animator ??= GetComponent<Animator>();
        }

        #endregion

        public void Freeze(bool state)
        {
            state = !state;

            _agent.enabled = state; 
            _movementAnimation.enabled = state;
            _movement.enabled = state;
            _animator.speed = state ? 1 : 0;
        }
    }
}
