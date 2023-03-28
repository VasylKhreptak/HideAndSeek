using CBA.Actions.Core;
using Data;
using UnityEngine;
using Zenject;

namespace Levels
{
    public abstract class LevelFinishedMarker : Action
    {
        [Header("Preferences")]
        [SerializeField] protected int _levelID;

        protected PlayerDataProvider _playerDataProvider;

        [Inject]
        private void Construct(PlayerDataProvider playerDataProvider)
        {
            _playerDataProvider = playerDataProvider;
        }
    }
}
