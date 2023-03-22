using System;
using CBA.Events.Core;
using Gameplay.Bots.SeekBot.Movement;
using UniRx;
using UnityEngine;
using Action = CBA.Actions.Core.Action;

namespace Boosters.HidePlayer
{
    public class InvisibleBooster : Action
    {
        [Header("References")]
        [SerializeField] private Transform _target;
        [SerializeField] private SeekPlayerBotMovement _botMovement;

        [Header("Preferences")]
        [SerializeField] private float _duration;

        [Header("Events")]
        [SerializeField] private MonoEvent _playerDiedEvent;

        private IDisposable _waitDisposable;

        #region MonoBehaviour

        private void OnValidate()
        {
            _botMovement ??= FindObjectOfType<SeekPlayerBotMovement>();
        }

        private void OnEnable()
        {
            _playerDiedEvent.onMonoCall += DisposeDelay;
        }

        private void OnDisable()
        {
            _playerDiedEvent.onMonoCall -= DisposeDelay;
        }

        #endregion


        public override void Do()
        {
            DisposeDelay();
            BecameInvisible();
            _waitDisposable = Observable.Timer(TimeSpan.FromSeconds(_duration)).Subscribe(_ => BecameVisible());
        }

        private void BecameInvisible()
        {
            _botMovement.RemoveTarget(_target);
        }

        private void BecameVisible()
        {
            _botMovement.AddTarget(_target);
        }

        private void DisposeDelay()
        {
            _waitDisposable?.Dispose();
        }
    }
}
