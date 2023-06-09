﻿using CBA.Animations.Physics.Rigidbody.Core;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace CBA.Animations.Physics.Rigidbody.Rotate
{
    public class RigidbodyRotateAnimation : RigidbodyAnimation
    {
        [Header("Rotate Preferences")]
        [SerializeField] private Vector3 _startAngle;
        [SerializeField] private Vector3 _targetAngle;

        public override Tween CreateForwardAnimation()
        {
            return _rigidbody.DORotate(_targetAngle, _duration);
        }

        public override Tween CreateBackwardAnimation()
        {
            return _rigidbody.DORotate(_startAngle, _duration);
        }

        public override void MoveToStartState()
        {
            _transform.rotation = Quaternion.Euler(_startAngle);
        }

        public override void MoveToEndState()
        {
            _transform.rotation = Quaternion.Euler(_targetAngle);
        }

        #region Editor

#if UNITY_EDITOR

        [ShowNonSerializedField] private bool _isRecording;

        [Button("Assign Start Angle")]
        private void AssignStartAngle()
        {
            if (_isRecording) return;

            _startAngle = _transform.rotation.eulerAngles;
        }

        [Button("Assign Target Position")]
        private void AssignTargetAngle()
        {
            if (_isRecording) return;

            _targetAngle = _transform.rotation.eulerAngles;
        }

        [Button("Rotate To Start")]
        private void RotateToStart()
        {
            if (_isRecording) return;

            MoveToStartState();
        }

        [Button("Rotate To End")]
        private void RotateToEnd()
        {
            if (_isRecording) return;

            MoveToEndState();
        }

        [Button("Start Recording")]
        private void StartRecording()
        {
            _startAngle = _transform.rotation.eulerAngles;

            _isRecording = true;
        }

        [Button("Stop Recording")]
        private void StopRecording()
        {
            if (_isRecording == false) return;

            _targetAngle = _transform.rotation.eulerAngles;
            MoveToStartState();

            _isRecording = false;
        }

#endif

        #endregion
        
    }
}
