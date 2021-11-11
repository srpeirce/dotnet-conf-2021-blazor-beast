namespace Timers;

//ToDo: Possibly something like this is better? https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-6.0&tabs=visual-studio#timed-background-tasks
public class ConditionalTimer : IConditionalTimer
{
    private readonly Func<TimeSpan> _nextInterval;

    public ConditionalTimer(Func<TimeSpan> nextInterval)
    {
        _nextInterval = nextInterval;
    }
    public event OnConditionalTimerTick? OnTimerTick;
    public event OnConditionalTimerComplete? OnTimerComplete;
    public event OnConditionalTimerCompleteAsync? OnTimerCompleteAsync;

    public async Task RepeatWhileAsync(Func<bool> condition)
    {
        while (condition())
        {
            await Task.Delay(_nextInterval());
            OnTimerTick?.Invoke();
        }
        
        OnTimerComplete?.Invoke();
        if (OnTimerCompleteAsync is not null)
        {
            await OnTimerCompleteAsync();
        }
    }
}