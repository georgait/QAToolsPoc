namespace QATools.Actions;

public class Click : ITask, ITarget<ITask>
{
    private Func<IPage, ILocator> _locationAction = default!;

    Click() { }

    public static Click OnLocator() => new();

    public ITask Using(Func<IPage, ILocator> locationAction)
    {
        _locationAction = locationAction;
        return this;
    }

    public async Task PerformTaskAsyncAs(IActor actor)
    {
        var page = (BrowseTheWeb.As(actor) as BrowseTheWeb).GetCurrentPage();

        await _locationAction(page).ClickAsync();
    }
}