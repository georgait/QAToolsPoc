namespace QATools.Pattern;

public interface IQuestion<T> 
    where T : class
{
    Task<T> AskAsyncAs(IActor actor);
}
