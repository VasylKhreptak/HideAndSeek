using CBA.Adapters.Alpha.Core;
using UnityEngine;
using Action = CBA.Actions.Core.Action;

namespace Actions.Graphics
{
    public class SetAlpha : Action
    {
        [Header("References")]
        [SerializeField] private AlphaAdapter _alphaAdapter;

        [Header("Preferences")]
        [SerializeField, Range(0f, 1f)] private float _alpha;

        #region MonoBehaviour

        private void OnValidate()
        {
            _alphaAdapter ??= GetComponent<AlphaAdapter>();
        }

        #endregion

        public override void Do()
        {
            _alphaAdapter.alpha = _alpha;
        }
    }
}
