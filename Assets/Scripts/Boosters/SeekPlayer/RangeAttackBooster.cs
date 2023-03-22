using System;
using UniRx;
using UnityEngine;
using Action = CBA.Actions.Core.Action;

namespace Boosters.SeekPlayer
{
    public class RangeAttackBooster : Action
    {
        [Header("References")]
        [SerializeField] private SphereCollider _attackZone;

        [Header("Preferences")]
        [SerializeField] private float _duration;
        [SerializeField] private float _targetRange;

        private float _baseRange;

        private IDisposable _disposable;

        #region MonoBehaviour

        private void Awake()
        {
            _baseRange = _attackZone.radius;
        }

        #endregion

        public override void Do()
        {
            _disposable?.Dispose();
            _attackZone.radius = _targetRange;
            _disposable = Observable.Timer(TimeSpan.FromSeconds(_duration)).Subscribe(_ => _attackZone.radius = _baseRange);
        }
    }
}
