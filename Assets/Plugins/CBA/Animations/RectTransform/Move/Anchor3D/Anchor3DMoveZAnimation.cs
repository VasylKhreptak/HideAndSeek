﻿using CBA.Animations.RectTransform.Core;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace CBA.Animations.RectTransform.Move.Anchor3D
{
    public class Anchor3DMoveZAnimation : RectTransformAnimation
    {
        [Header("Move Preferences")]
        [SerializeField] private float _startAnchorZ;
        [SerializeField] private float _targetAnchorZ;

        [Header("Snapping")]
        [SerializeField] private bool _snapping;

        public override Tween CreateForwardAnimation()
        {
            return _rectTransform.DOAnchorPos3DZ(_targetAnchorZ, _duration, _snapping);
        }

        public override Tween CreateBackwardAnimation()
        {
            return _rectTransform.DOAnchorPos3DZ(_startAnchorZ, _duration, _snapping);
        }

        public override void MoveToStartState()
        {
            Vector3 anchoredPosition = _rectTransform.anchoredPosition3D;
            _rectTransform.anchoredPosition3D = new Vector3(anchoredPosition.x, anchoredPosition.y, _startAnchorZ);
        }

        public override void MoveToEndState()
        {
            Vector3 anchoredPosition = _rectTransform.anchoredPosition3D;
            _rectTransform.anchoredPosition3D = new Vector3(anchoredPosition.x, anchoredPosition.y, _targetAnchorZ);
        }

        #region Editor

#if UNITY_EDITOR

        [ShowNonSerializedField] private bool _isRecording;

        [Button("Assign Start Anchor Position")]
        private void AssignStartPosition()
        {
            if (_isRecording) return;

            _startAnchorZ = _rectTransform.anchoredPosition3D.z;
        }

        [Button("Assign Target Anchor Position")]
        private void AssignTargetPosition()
        {
            if (_isRecording) return;

            _targetAnchorZ = _rectTransform.anchoredPosition3D.z;
        }

        [Button("Move To Start")]
        private void MoveToStartPositionEditor()
        {
            if (_isRecording) return;

            MoveToStartState();
        }

        [Button("Move To End")]
        private void MoveToTargetPosition()
        {
            if (_isRecording) return;

            MoveToEndState();
        }

        [Button("Start Recording")]
        private void StartRecording()
        {
            _startAnchorZ = _rectTransform.anchoredPosition3D.z;

            _isRecording = true;
        }

        [Button("Stop Recording")]
        private void StopRecording()
        {
            if (_isRecording == false) return;

            _targetAnchorZ = _rectTransform.anchoredPosition3D.z;
            MoveToStartState();

            _isRecording = false;
        }

        private void OnDrawGizmosSelected()
        {
            if (_rectTransform == null) return;

            if (_isRecording)
            {
                DrawRecordingArrow();
            }
            else
            {
                DrawDefaultArrow();
            }
        }

        private void DrawDefaultArrow()
        {
            // Vector2 direction = _targetAnchoredPosition - _startAnchoredPosition;
            // Vector3 startPosition = _rectTransform.TransformPoint(_startAnchoredPosition);
            //
            // Gizmos.color = Color.white;
            // Extensions.Gizmos.DrawArrow(startPosition, direction);
        }

        private void DrawRecordingArrow()
        {
            // Vector2 anchoredPosition = _rectTransform.anchoredPosition;
            // Vector2 direction = anchoredPosition - _startAnchoredPosition;
            // Vector3 startPosition = _rectTransform.TransformPoint(_startAnchoredPosition);
            //
            // Gizmos.color = Color.red;
            // Gizmos.DrawSphere(_startAnchoredPosition, 0.1f);
            // Extensions.Gizmos.DrawArrow(startPosition, direction);
        }

#endif

        #endregion

    }
}
