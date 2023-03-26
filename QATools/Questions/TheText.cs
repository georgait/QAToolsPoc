namespace QATools.Questions;

public class TheText : IQuestion<string>, IAction<IQuestion<string>>
{
    private Func<IPage, ILocator> _locationAction = default!;

    TheText() { }

    public static TheText OfLocator() => new();

    public IQuestion<string> Using(Func<IPage, ILocator> locationAction)
    {
        _locationAction = locationAction;
        return this;
    }

    public async Task<string> AskAsyncAs(IActor actor)
    {
        var page = (BrowseTheWeb.As(actor) as BrowseTheWeb).GetCurrentPage();
        return await _locationAction(page).TextContentAsync();
    }
}
