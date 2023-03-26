namespace QATools.Actions;

public class OpenNewWindow : ITask, IAction<ITask>
{
    private readonly string _name;
    private Func<IPage, ILocator> _locationAction = default!;

    OpenNewWindow(string name)
    {
        _name = name;
    }

    public static OpenNewWindow Named(string name) => new(name);

    public ITask Using(Func<IPage, ILocator> locationAction)
    {
        _locationAction = locationAction;
        return this;
    }

    public async Task PerformTaskAsyncAs(IActor actor)
    {
        var browseTheWeb = BrowseTheWeb.As(actor) as BrowseTheWeb;

        var basePage = browseTheWeb.GetCurrentPage();
        await browseTheWeb.WithChildPage(_name, async () =>
        {
            await _locationAction(basePage).ClickAsync();
        });
    }
}
