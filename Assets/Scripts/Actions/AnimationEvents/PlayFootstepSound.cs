using Providers.Core;
using UnityEngine;
using Action = CBA.Actions.Core.Action;

namespace Actions.AnimationEvents
{
    public class PlayFootstepSound : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Action _action;
        [SerializeField] private Vector3Provider _speedProvider;

        [Header("Preferences")]
        [SerializeField] private float _minSpeed = 2f;

        #region MonoBehaviour

        private void OnValidate()
        {
            _action ??= GetComponent<Action>();
            _speedProvider ??= GetComponent<Vector3Provider>();
        }

        #endregion

        public void PlayFootStep()
        {
            if (_speedProvider.vector.magnitude > _minSpeed)
            {
                _action.Do();
            }
        }
    }
}
