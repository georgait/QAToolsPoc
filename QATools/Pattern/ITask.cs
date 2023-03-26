namespace QATools.Pattern;

public interface ITask
{
    Task PerformTaskAsyncAs(IActor actor);
}
