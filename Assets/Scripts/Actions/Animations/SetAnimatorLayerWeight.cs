using UnityEngine;
using Action = CBA.Actions.Core.Action;

namespace Actions.Animations
{
    public class SetAnimatorLayerWeight : Action
    {
        [Header("References")]
        [SerializeField] private Animator _animator;

        [Header("Preferences")]
        [SerializeField] private int _layerIndex;
        [SerializeField, Range(0f, 1f)] private float _weight;

        #region MonoBehaviour

        private void OnValidate()
        {
            _animator ??= GetComponent<Animator>();
        }

        #endregion

        public override void Do()
        {
            _animator.SetLayerWeight(_layerIndex, _weight);
        }
    }
}
