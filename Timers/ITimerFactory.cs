namespace Timers;

public interface ITimerFactory
{
    IConditionalTimer NewConditionalTimer(Func<TimeSpan> nextTimespan);
}