namespace QATools.Pages;

public static class TopNavBar
{
    public static ILocator SearchLabelBtn(IPage page)
    {
        return page.GetByRole(AriaRole.Button, new() { Name = "Search" });
    }

    public static ILocator SearchDocs(IPage page)
    {
        return page.GetByPlaceholder("Search docs");
    }
}