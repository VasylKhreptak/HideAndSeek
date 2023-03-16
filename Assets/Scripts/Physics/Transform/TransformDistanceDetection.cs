using System;
using UniRx;
using UnityEngine;
using Color = CBA.Extensions.Color;

namespace Physics.Transform
{
    public class TransformDistanceDetection : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private UnityEngine.Transform _source;
        [SerializeField] private UnityEngine.Transform _target;

        [Header("Preferences")]
        [SerializeField] private float _range;
        [SerializeField] private float _checkInterval = 1f;

        public event Action onEnter;
        public event Action onExit;

        private ReactiveProperty<bool> _isInsideReactiveProperty = new ReactiveProperty<bool>();

        private CompositeDisposable _disposable = new CompositeDisposable();

        #region MonoBehaviour

        private void OnValidate()
        {
            _source ??= GetComponent<UnityEngine.Transform>();
        }

        private void OnEnable()
        {
            StartChecking();
        }

        private void OnDisable()
        {
            StopChecking();
        }

        #endregion

        private void StartChecking()
        {
            _isInsideReactiveProperty.Subscribe(isInside =>
            {
                (isInside ? onEnter : onExit)?.Invoke();
            }).AddTo(_disposable);

            Observable.Interval(TimeSpan.FromSeconds(_checkInterval)).Subscribe(_ =>
            {
                _isInsideReactiveProperty.Value = Vector3.Distance(_source.position, _target.position) <= _range;
            }).AddTo(_disposable);
        }

        private void StopChecking()
        {
            _disposable.Dispose();
        }

        private void OnDrawGizmosSelected()
        {
            if (_source == null) return;

            Gizmos.color = Color.WithAlpha(UnityEngine.Color.red, 0.3f);
            Gizmos.DrawSphere(_source.position, _range);
        }
    }
}
