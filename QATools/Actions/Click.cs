namespace QATools.Actions;

public class Click : ITask, ITarget<ITask>
{
    private Func<IPage, ILocator> _locationAction = default!;

    Click() { }

    public static Click OnTarget() => new();

    public ITask UsingDynamicLocator(Func<IPage, ILocator> locationAction)
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