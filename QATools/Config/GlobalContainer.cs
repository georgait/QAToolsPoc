using BoDi;

namespace QATools.Config;

public static class GlobalContainer
{
    private static IObjectContainer _container = new ObjectContainer();

    public static void Register<T>(T instance, string name)
        where T : class
    {
        _container.RegisterInstanceAs(instance, name);  
    }

    public static bool TryResolve<T>(string name, out T? t)
        where T : class
    {
        try
        {
            t = _container.Resolve<T>(name);
            return true;
        }
        catch
        {
            t = null;
        }

        return false;
    }

    public static IEnumerable<T> ResolveAll<T>()
        where T : class
    {
        return _container.ResolveAll<T>();
    }
}
