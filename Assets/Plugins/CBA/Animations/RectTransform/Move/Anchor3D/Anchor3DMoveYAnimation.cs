﻿using CBA.Animations.RectTransform.Core;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace CBA.Animations.RectTransform.Move.Anchor3D
{
    public class Anchor3DMoveYAnimation : RectTransformAnimation
    {
        [Header("Move Preferences")]
        [SerializeField] private float _startAnchorY;
        [SerializeField] private float _targetAnchorY;

        [Header("Snapping")]
        [SerializeField] private bool _snapping;

        public override Tween CreateForwardAnimation()
        {
            return _rectTransform.DOAnchorPos3DY(_targetAnchorY, _duration, _snapping);
        }

        public override Tween CreateBackwardAnimation()
        {
            return _rectTransform.DOAnchorPos3DY(_startAnchorY, _duration, _snapping);
        }

        public override void MoveToStartState()
        {
            Vector3 anchoredPosition = _rectTransform.anchoredPosition3D;
            _rectTransform.anchoredPosition3D = new Vector3(anchoredPosition.x, _startAnchorY, anchoredPosition.z);
        }

        public override void MoveToEndState()
        {
            Vector3 anchoredPosition = _rectTransform.anchoredPosition3D;
            _rectTransform.anchoredPosition3D = new Vector3(anchoredPosition.x, _targetAnchorY, anchoredPosition.z);
        }

        #region Editor

#if UNITY_EDITOR

        [ShowNonSerializedField] private bool _isRecording;

        [Button("Assign Start Anchor Position")]
        private void AssignStartPosition()
        {
            if (_isRecording) return;

            _startAnchorY = _rectTransform.anchoredPosition3D.y;
        }

        [Button("Assign Target Anchor Position")]
        private void AssignTargetPosition()
        {
            if (_isRecording) return;

            _targetAnchorY = _rectTransform.anchoredPosition3D.y;
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
            _startAnchorY = _rectTransform.anchoredPosition3D.y;

            _isRecording = true;
        }

        [Button("Stop Recording")]
        private void StopRecording()
        {
            if (_isRecording == false) return;

            _targetAnchorY = _rectTransform.anchoredPosition3D.y;
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
