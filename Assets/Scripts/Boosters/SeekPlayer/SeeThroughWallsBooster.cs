using System;
using UniRx;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Action = CBA.Actions.Core.Action;

namespace Boosters.SeekPlayer
{
    public class SeeThroughWallsBooster : Action
    {
        [Header("References")]
        [SerializeField] private ScriptableRendererFeature _playerHiddenFeature;

        [Header("Preferences")]
        [SerializeField] private float _duration;

        private IDisposable _disposable;

        public override void Do()
        {
            _disposable?.Dispose();
            _playerHiddenFeature.SetActive(true);
            _disposable = Observable.Timer(TimeSpan.FromSeconds(_duration)).Subscribe(_ => _playerHiddenFeature.SetActive(false));
        }
    }
}
