namespace QATools.Actions;

public class Enter : ITask, ITarget<ITask>
{
    private readonly string _value;
    private Func<IPage, ILocator> _locationAction = default!; 

    private Enter(string value)
    {
        _value = value;
    }

    public static Enter TheValue(string value) => new(value);
    
    public ITask UsingDynamicLocator(Func<IPage, ILocator> locationAction)
    {
        _locationAction = locationAction;
        return this;
    }

    public async Task PerformTaskAsyncAs(IActor actor)
    {
        // #1 - Page
        var page = (BrowseTheWeb.As(actor) as BrowseTheWeb).GetCurrentPage();

        // #2 - Locator 
        var locator = _locationAction(page);

        // #3 - Action
        await locator.FillAsync(_value);
    }
}