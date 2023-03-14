using System;
using UniRx;
using UnityEngine;

namespace UI
{
    public class ScrollViewLayerSorting : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _contentTransform;
        [SerializeField] private ScrollViewSnapping _scrollViewSnapping;

        private IDisposable _subscription;

        private int _childCount;

        #region MonoBehaviour

        private void OnValidate()
        {
            _contentTransform ??= GetComponent<Transform>();
            _scrollViewSnapping ??= FindObjectOfType<ScrollViewSnapping>();
        }

        private void Awake()
        {
            _childCount = _contentTransform.childCount;
        }

        private void OnEnable()
        {
            _subscription = _scrollViewSnapping.CurrentObjectProperty.Subscribe(UpdateLayers);
        }

        private void OnDisable()
        {
            _subscription.Dispose();
        }

        #endregion

        private void UpdateLayers(Transform selectedObject)
        {
            
        }
    }
}
