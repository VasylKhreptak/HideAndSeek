using CBA.Adapters.Float.Core;
using DG.Tweening;
using UnityEngine;
using Action = CBA.Actions.Core.Action;

namespace Actions
{
    public class BoostPlayerSpeed : Action
    {
        [Header("References")]
        [SerializeField] private FloatAdapter _speedAdapter;

        [Header("Preferences")]
        [SerializeField] private float _boostPercentageAmount;
        [SerializeField] private float _boostDuration;
        [SerializeField] private AnimationCurve _boostCurve;

        private float _baseSpeed;

        private float _boostedSpeed;

        private Tween _boostTween;

        #region MonoBehaviour

        private void Awake()
        {
            _speedAdapter ??= GetComponent<FloatAdapter>();
            _baseSpeed = _speedAdapter.value;
            _boostedSpeed = _baseSpeed + _baseSpeed * _boostPercentageAmount / 100f;
        }

        private void OnDisable()
        {
            _boostTween.Kill();
        }

        #endregion

        public override void Do()
        {
            _boostTween.Kill();
            _boostTween = DOTween
                .To(() => _speedAdapter.value, value => _speedAdapter.value = value, _boostedSpeed, _boostDuration)
                .SetEase(_boostCurve)
                .OnComplete(() => _speedAdapter.value = _baseSpeed)
                .Play();
        }
    }
}
