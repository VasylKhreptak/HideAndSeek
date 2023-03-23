using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Animation = CBA.Animations.Core.Animation;

namespace Animations
{
    public class SaturationAnimation : Animation
    {
        [Header("References")]
        [SerializeField] private Volume _volume;

        [Header("Preferences")]
        [SerializeField, Range(-100f, 100f)] private float _startSaturation;
        [SerializeField, Range(-100f, 100f)] private float _targetSaturation;

        private ColorAdjustments _colorAdjustments;

        #region MonoBehaviour

        private void OnValidate()
        {
            _volume ??= FindObjectOfType<Volume>();
        }

        private void Awake()
        {
            _volume.profile.TryGet(out _colorAdjustments);
        }

        #endregion

        public override Tween CreateForwardAnimation()
        {
            return DOTween.To(() => _colorAdjustments.saturation.value, x => _colorAdjustments.saturation.value = x, _targetSaturation, _duration);
        }

        public override Tween CreateBackwardAnimation()
        {
            return DOTween.To(() => _colorAdjustments.saturation.value, x => _colorAdjustments.saturation.value = x, _startSaturation, _duration);

        }

        public override void MoveToStartState()
        {
            _colorAdjustments.saturation.value = _startSaturation;
        }

        public override void MoveToEndState()
        {
            _colorAdjustments.saturation.value = _targetSaturation;
        }
    }
}
