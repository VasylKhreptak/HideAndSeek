using Providers.Core;
using UnityEngine;
using UnityEngine.AI;

namespace Providers
{
    public class AgentVelocityProvider : Vector3Provider
    {
        [Header("References")]
        [SerializeField] private NavMeshAgent _agent;

        #region MonoBehaviour

        private void OnValidate()
        {
            _agent ??= GetComponent<NavMeshAgent>();
        }

        #endregion

        public override Vector3 vector
        {
            get => _agent.velocity;
        }
    }
}
