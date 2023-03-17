using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Action = CBA.Actions.Core.Action;

namespace Actions.Graphics
{
    public class DistortCameraLens : Action
    {
        [Header("References")]
        [SerializeField] private Volume _volume;

        [Header("Preferences")]
        [SerializeField] private float _targetIntensity;
        [SerializeField] private float _duration;
        [SerializeField] private AnimationCurve _curve;

        private float _baseIntensity;

        private Tween _distortionTween;

        private LensDistortion _lensDistortion;

        #region MonoBehaviour

        private void OnValidate()
        {
            _volume ??= FindObjectOfType<Volume>();
        }

        private void Awake()
        {
            _volume.profile.TryGet(out _lensDistortion);
            _baseIntensity = _lensDistortion.intensity.value;
        }

        private void OnDestroy()
        {
            _distortionTween.Kill();
        }

        #endregion

        public override void Do()
        {
            _distortionTween.Kill();
            _lensDistortion.intensity.value = _baseIntensity;
            _distortionTween = DOTween
                .To(() => _lensDistortion.intensity.value, value => _lensDistortion.intensity.value = value, _targetIntensity, _duration)
                .SetEase(_curve)
                .OnComplete(() => _lensDistortion.intensity.value = _baseIntensity)
                .Play();
        }
    }
}
