namespace Levels
{
    public class MarkSeekLevelAsCompleted : LevelFinishedMarker
    {
        public override void Do()
        {
            _playerDataProvider.Data.levels[_levelID].seekPlayerFinished = true;
        }
    }
}
