namespace QATools.Pattern;

public class Target
{
    private readonly IPage _page;

    public Target(IPage page)
    {
        _page = page;
    }

    public static Target The(IPage page) => new(page);

    public ILocator AndLocate(Func<IPage, ILocator> locate) => locate(_page);
}