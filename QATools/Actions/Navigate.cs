namespace QATools.Actions;

public class Navigate : ITask
{
    private readonly string _url;

    public Navigate(string url)
    {
        _url = url;
    }

    public static Navigate To(string url) => new(url);
    
    public async Task PerformTaskAsyncAs(IActor actor)
    {
        var page = (BrowseTheWeb.As(actor) as BrowseTheWeb)!.GetCurrentPage();
        await page.GotoAsync(_url);
    }
}
