using CBA.Adapters.Float.Core;
using UnityEngine;
using UnityEngine.AI;

namespace Adapters
{
    public class AdaptedAgentForSpeed : FloatAdapter
    {
        [Header("References")]
        [SerializeField] private NavMeshAgent _agent;

        #region MonoBehaviour

        private void OnValidate()
        {
            _agent ??= GetComponent<NavMeshAgent>();
        }

        #endregion

        public override float value
        {
            get => _agent.speed;
            set => _agent.speed = value;
        }
    }
}
