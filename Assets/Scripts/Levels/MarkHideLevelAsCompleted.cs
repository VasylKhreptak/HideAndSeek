namespace Levels
{
    public class MarkHideLevelAsCompleted : LevelFinishedMarker
    {
        public override void Do()
        {
            _playerDataProvider.Data.levels[_levelID].hidePlayerFinished = true;
        }
    }
}
