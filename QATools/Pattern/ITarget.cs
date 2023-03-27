namespace QATools.Pattern;

public interface ITarget<out T>
    where T : class
{
    T UsingDynamicLocator(Func<IPage, ILocator> locationAction);
}