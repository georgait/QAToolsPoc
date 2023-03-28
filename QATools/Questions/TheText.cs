namespace QATools.Questions;

public class TheText : IQuestion<string>
{
    private readonly Func<IPage, ILocator> _locate;

    public TheText(Func<IPage, ILocator> _locate)
    {
        this._locate = _locate;
    }

    public static TheText OfTarget(Func<IPage, ILocator> locate) => new(locate);

    public async Task<string> AskAsyncAs(IActor actor)
    {
        var page = (BrowseTheWeb.As(actor) as BrowseTheWeb).GetCurrentPage();
        
        return await Target
            .ThePage(page)
            .GetLocator(_locate)
            .TextContentAsync();
    }
}
