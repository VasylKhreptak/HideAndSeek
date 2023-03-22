using UnityEngine;
using Action = CBA.Actions.Core.Action;

namespace Actions.Animations
{
    public class SetAnimatorTrigger : Action
    {
        [Header("References")]
        [SerializeField] private Animator _animator;

        [Header("Preferences")]
        [SerializeField] private string _triggerName;

        #region MonoBehaviour

        private void OnValidate()
        {
            _animator ??= GetComponent<Animator>();
        }

        #endregion

        public override void Do()
        {
            _animator.ResetTrigger(_triggerName);
            _animator.SetTrigger(_triggerName);
        }
    }
}
