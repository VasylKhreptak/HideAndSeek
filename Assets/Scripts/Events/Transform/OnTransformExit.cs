using System;
using CBA.Events.Core;
using Physics.Transform;
using UnityEngine;

namespace Events.Transform
{
    public class OnTransformExit : MonoEvent
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
            _transformDistanceDetection.onExit += Invoke;
        }

        private void OnDisable()
        {
            _transformDistanceDetection.onExit -= Invoke;
        }

        #endregion
    }
}
