using System;
using UniRx;
using UnityEngine;

namespace Screen.Pointer
{
    public class Pointer : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _pointerTransform;

        [Header("Offset Preferences")]
        [SerializeField] private float _angleOffset;
        [SerializeField] private float _leftOffset;
        [SerializeField] private float _rightOffset;
        [SerializeField] private float _upOffset;
        [SerializeField] private float _downOffset;

        [HideInInspector] public BoolReactiveProperty isOnScreen;

        public Transform PointerTransform => _pointerTransform;

        public float AngleOffset => _angleOffset;
        public float LeftOffset => _leftOffset;
        public float RightOffset => _rightOffset;
        public float UpOffset => _upOffset;
        public float DownOffset => _downOffset;

        public event Action onScreenEnter;
        public event Action onScreenExit;

        private IDisposable _disposable;

        #region MonoBehaviour

        private void Start()
        {
            (isOnScreen.Value ? onScreenEnter : onScreenExit)?.Invoke();
        }

        private void OnEnable()
        {
            _disposable = isOnScreen.Subscribe(isOnScreen => (isOnScreen ? onScreenEnter : onScreenExit)?.Invoke());
        }

        private void OnDisable()
        {
            _disposable.Dispose();
        }

        #endregion
    }
}
