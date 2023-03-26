using BoDi;

namespace QATools.Extensions;

public static class ContainerExtensions
{
    public static bool TryResolve<T>(this IObjectContainer container, string name, out T? t)
        where T : class
    {
        try
        {
            t = container.Resolve<T>(name);
            return true;
        }
        catch 
        { 
            t = null; 
        }

        return false;
    }
}
