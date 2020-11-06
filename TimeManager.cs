public class TimeManager : MonoSingleton<TimeManager>
{
    private float startTime;
    private float endTime;

    private int hours;

    private int minutes;
    private int minutesTens;
    private int minutesOnes;

    private int seconds;
    private int secondsTens;
    private int secondsOnes;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetStartTime(float time)
    {
        endTime = time;
    }

    public void SetEndTime(float time)
    {
        endTime = time;
    }

    private void CalculateSeconds()
    {
        seconds = (int)endTime - (int)startTime;
    }

    private void CalculateMinutes()
    {
        minutes = seconds / 60;
        seconds -= (60 * minutes);
        secondsTens = seconds / 10;
        secondsOnes = seconds % 10;
    }

    private void CalculateHours()
    {
        hours = minutes / 60;
        minutes -= (60 * hours);
        minutesTens = minutes / 10;
        minutesOnes = minutes % 10;
    }

    public string GetTime()
    {
        CalculateSeconds();
        CalculateMinutes();
        CalculateHours();

        return hours + ":" + minutesTens + minutesOnes + ":" + secondsTens + secondsOnes;
    }
}
