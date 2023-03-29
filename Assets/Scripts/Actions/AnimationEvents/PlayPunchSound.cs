using UnityEngine;
using Action = CBA.Actions.Core.Action;

namespace Actions.AnimationEvents
{
    public class PlayPunchSound : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Action _action;

        #region MonoBehaviour

        private void OnValidate()
        {
            _action ??= GetComponent<Action>();
        }

        #endregion

        public void PlayPunch()
        {
            _action.Do();
        }
    }
}
