namespace Timers;

public delegate void OnConditionalTimerTick();
public delegate void OnConditionalTimerComplete();
public delegate Task OnConditionalTimerCompleteAsync();

public interface IConditionalTimer
{
    event OnConditionalTimerTick OnTimerTick;
    event OnConditionalTimerComplete OnTimerComplete;
    event OnConditionalTimerCompleteAsync OnTimerCompleteAsync;
    Task RepeatWhileAsync(Func<bool> condition);
}