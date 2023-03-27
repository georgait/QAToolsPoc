namespace QATools.Pattern;

public interface ITarget<out T>
    where T : class
{
    T Using(Func<IPage, ILocator> locationAction);
}
