namespace QATools.Actions;

public class Target
{
    private readonly IPage _page;

    public Target(IPage page)
    {
        _page = page;
    }

    public static Target ThePage(IPage page) => new(page);

    public ILocator GetLocator(Func<IPage, ILocator> locate) => locate(_page);
}
