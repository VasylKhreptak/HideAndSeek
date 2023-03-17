using System;
using CBA.Events.Core;
using CBA.Events.Physics._3D;
using DG.Tweening;
using Map;
using UnityEngine;

namespace Gameplay.HidePlayer
{
    public class AreaInspector : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private KeyHolder _keyHolder;

        [Header("Events")]
        [SerializeField] private OnTriggerEnterEvent _triggerEnterEvent;
        [SerializeField] private MonoEvent _triggerExitEvent;

        [Header("Preferences")]
        [SerializeField] private float _inspectionTime;

        public Action onStartedInspection;
        public Action onStoppedInspection;
        public Action onInspectedSuccessfully;
        public Action onInspectedUnsuccessfully;
        public Action<float> onInspectionProgressUpdated;

        private Tween _inspectionTween;

        private float _progress;

        #region MonoBehaviour

        private void OnEnable()
        {
            _triggerEnterEvent.onEnter += StartInspection;
            _triggerExitEvent.onMonoCall += StopInspection;
        }

        private void OnDisable()
        {
            StopInspection();

            _triggerEnterEvent.onEnter -= StartInspection;
            _triggerExitEvent.onMonoCall -= StopInspection;
        }

        #endregion

        private void StartInspection(Collider collider)
        {
            if (collider.TryGetComponent(out InspectionArea area) == false) return;
            if(area.inspected) return;
            
            _inspectionTween.Kill();
            _progress = 0;
            _inspectionTween = DOTween
                .To(() => _progress, x => _progress = x, 1, _inspectionTime)
                .OnStart(onStartedInspection.Invoke)
                .OnUpdate(() => onInspectionProgressUpdated.Invoke(_progress))
                .OnComplete(() => OnInspectionCompleted(area))
                .OnKill(onStoppedInspection.Invoke)
                .Play();
        }

        private void StopInspection()
        {
            _inspectionTween.Kill();
            _progress = 0;
        }

        private void OnInspectionCompleted(InspectionArea area)
        {
            if (area.hasKey && area.inspected == false)
            {
                onInspectedSuccessfully?.Invoke();
                area.inspected = true;
                _keyHolder.PlaceKey();
            }
            else
            {
                onInspectedUnsuccessfully?.Invoke();
            }

            onStoppedInspection?.Invoke();
            _progress = 0;
        }
    }
}
