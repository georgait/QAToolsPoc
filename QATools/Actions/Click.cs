namespace QATools.Actions;

public class Click : ITask
{
    private readonly Func<IPage, ILocator> _locate;

    public Click(Func<IPage, ILocator> locationAction)
    {
        _locate = locationAction;
    }

    public static Click OnTarget(Func<IPage, ILocator> locate)
    {
        return new(locate);
    }

    public async Task PerformTaskAsyncAs(IActor actor)
    {
        var page = (BrowseTheWeb.As(actor) as BrowseTheWeb).GetCurrentPage();
        await Target.The(page).AndLocate(_locate).ClickAsync();
    }
}
