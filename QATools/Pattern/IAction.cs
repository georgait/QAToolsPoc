namespace QATools.Pattern;

public interface IAction<out T>
    where T : class
{
    T Using(Func<IPage, ILocator> locationAction);
}
