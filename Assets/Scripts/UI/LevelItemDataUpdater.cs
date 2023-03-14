using CBA.Actions.Core;
using Data;
using UnityEngine;
using Zenject;

namespace UI
{
    public class LevelItemDataUpdater : MonoBehaviour
    {
        [Header("Preferences")]
        [SerializeField] private int _levelID;

        [Header("Actions")]
        [SerializeField] private Action _enableCompletionSign;
        [SerializeField] private Action _enableHidePlayer;
        [SerializeField] private Action _enableSeekPlayer;

        private PlayerDataProvider _playerDataProvider;

        [Inject]
        private void Construct(PlayerDataProvider playerDataProvider)
        {
            _playerDataProvider = playerDataProvider;
        }

        #region MonoBehaviour

        private void Start()
        {
            UpdateUI(GetLevelData());
        }

        #endregion

        private LevelData GetLevelData()
        {
            return _playerDataProvider.Data.levels[_levelID];
        }

        private void UpdateUI(LevelData levelData)
        {
            if (levelData.hidePlayerFinished)
                _enableHidePlayer.Do();

            if (levelData.seekPlayerFinished)
                _enableSeekPlayer.Do();

            if (levelData.hidePlayerFinished || levelData.seekPlayerFinished)
                _enableCompletionSign.Do();
        }
    }
}
