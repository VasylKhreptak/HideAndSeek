using System;
using Extensions;
using UniRx;
using UnityEngine;
using Action = CBA.Actions.Core.Action;

namespace Boosters.HidePlayer
{
    public class GhostBooster : Action
    {
        [Header("Layer Preferences")]
        [SerializeField] private LayerMask _playerLayerMask;
        [SerializeField] private LayerMask _wallLayerMask;

        [Header("Preferences")]
        [SerializeField] private float _duration;

        private IDisposable _disposable;

        public override void Do()
        {
            _disposable?.Dispose();
            IgnoreWalls(true);
            _disposable = Observable.Timer(TimeSpan.FromSeconds(_duration)).Subscribe(_ => IgnoreWalls(false));
        }

        private void IgnoreWalls(bool state)
        {
            UnityEngine.Physics.IgnoreLayerCollision(_playerLayerMask.GetIndex(), _wallLayerMask.GetIndex(), state);
        }
    }
}
