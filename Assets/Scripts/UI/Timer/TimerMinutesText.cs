namespace UI.Timer
{
    public class TimerMinutesText : TimerPartText
    {
        protected override void UpdateText(int seconds)
        {
            _tmp.text = (seconds / 60).ToString("00");
        }
    }
}
