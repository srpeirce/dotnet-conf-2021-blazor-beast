namespace Timers.Testing;

public class FakeConditionalTimer : IConditionalTimer
{
    public event OnConditionalTimerTick? OnTimerTick;
    public event OnConditionalTimerComplete? OnTimerComplete;
    public event OnConditionalTimerCompleteAsync? OnTimerCompleteAsync;

    public bool IsLoopComplete { get; private set; }
    public async Task RepeatWhileAsync(Func<bool> condition)
    {
        while (condition())
        {
            await Task.Delay(TimeSpan.FromMilliseconds(100));
        }

        IsLoopComplete = true;
    }

    public void TickTimer()
    {
        OnTimerTick?.Invoke();
    }

    /// <summary>
    /// Just an awkward race condition for testing - review this later.
    /// </summary>
    public async Task WaitForLoopToCompleteAndCallOnTimeUp()
    {
        var maxTimeMilliseconds = 1000;
        var timeSoFar = 0;
        
        while (!IsLoopComplete)
        {
            if (timeSoFar > maxTimeMilliseconds)
            {
                throw new Exception("Timed Out");
            }
            await Task.Delay(TimeSpan.FromMilliseconds(100));
            timeSoFar += 100;
        }
        
        OnTimerComplete?.Invoke();
        if (OnTimerCompleteAsync is not null)
        {
            await OnTimerCompleteAsync();
        }
    }
}