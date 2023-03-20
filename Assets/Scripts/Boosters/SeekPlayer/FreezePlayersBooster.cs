using System;
using Gameplay.Bots.HideBot.Movement;
using Gameplay.Players;
using UniRx;
using UnityEngine;
using Action = CBA.Actions.Core.Action;

namespace Boosters.SeekPlayer
{
    public class FreezePlayersBooster : Action
    {
        [Header("Preferences")]
        [SerializeField] private HidePlayerBotFreezer[] _freezers;
        [SerializeField] private float _duration;

        private void OnValidate()
        {
            _freezers ??= FindObjectsOfType<HidePlayerBotFreezer>();
        }

        private IDisposable _disposable;

        public override void Do()
        {
            _disposable?.Dispose();
            Freeze(true);
            _disposable = Observable.Timer(TimeSpan.FromSeconds(_duration)).Subscribe(_ => Freeze(false));
        }

        private void Freeze(bool state)
        {
            foreach (var freezer in _freezers)
            {
                if (state)
                {
                    freezer.Freeze(true);
                }
                else
                {
                    KillableObject killableObject = freezer.GetComponent<KillableObject>();

                    if (killableObject.IsKilled == false)
                    {
                        freezer.Freeze(false);
                    }
                }
            }
        }
    }
}
