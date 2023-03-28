namespace QATools.Actions;

public class OpenNewWindow : ITask
{
    private readonly string _name;
    private Func<IPage, ILocator> _locate;

    public OpenNewWindow(string name)
    {
        _name = name;
    }

    public static OpenNewWindow Named(string name) => new(name);

    public OpenNewWindow UsingTarget(Func<IPage, ILocator> locate)
    {
        _locate = locate;
        return this;
    }

    public async Task PerformTaskAsyncAs(IActor actor)
    {
        var browseTheWeb = BrowseTheWeb.As(actor) as BrowseTheWeb;

        var basePage = browseTheWeb.GetCurrentPage();
        await browseTheWeb.WithChildPage(_name, async () =>
        {
            await Target.ThePage(basePage).GetLocator(_locate).ClickAsync();
        });
    }
}
