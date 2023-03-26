namespace QATools.Pages;

public static class HomePage 
{ 
    public static ILocator GetStartedBtn(IPage page)
    {
        return page.GetByRole(AriaRole.Link, new() { Name = "Get started" });
    }
}
