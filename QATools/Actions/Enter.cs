namespace QATools.Actions;

public class Enter : ITask
{
    private readonly Func<IPage, ILocator> _locate;
    private string _value;

    public Enter(Func<IPage, ILocator> locationAction)
    {
        _locate = locationAction;
    }

    public static Enter OnTarget(Func<IPage, ILocator> locate) => new(locate);

    public Enter TheValue(string value)
    {
        _value = value;
        return this;
    }

    public async Task PerformTaskAsyncAs(IActor actor)
    {
        // #1 - Page
        var page = (BrowseTheWeb.As(actor) as BrowseTheWeb).GetCurrentPage();

        // #2 - Locator         
        var locator = Target.The(page).AndLocate(_locate);

        // #3 - Action
        await locator.FillAsync(_value);
    }
}
