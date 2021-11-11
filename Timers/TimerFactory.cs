namespace Timers;

public class TimerFactory : ITimerFactory
{
    public IConditionalTimer NewConditionalTimer(Func<TimeSpan> nextTimespan)
    {
        return new ConditionalTimer(nextTimespan);
    }
}