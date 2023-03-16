using CBA.Events.Core;
using Physics.Transform;
using UnityEngine;

namespace Events.Transform
{
    public class OnTransformEnter : MonoEvent
    {
        [Header("References")]
        [SerializeField] private TransformDistanceDetection _transformDistanceDetection;

        #region MonoBeahviour

        private void OnValidate()
        {
            _transformDistanceDetection ??= GetComponent<TransformDistanceDetection>();
        }

        private void OnEnable()
        {
            _transformDistanceDetection.onEnter += Invoke;
        }

        private void OnDisable()
        {
            _transformDistanceDetection.onEnter -= Invoke;
        }

        #endregion
    }
}
