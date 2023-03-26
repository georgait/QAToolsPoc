namespace QATools.Pages;

public static class TraceView
{
    public static ILocator Page(IPage page)
    {
        return page.GetByRole(AriaRole.Paragraph).Filter(new() 
        { 
            HasText = "trace.playwright.dev is a statically hosted variant of the Trace Viewer. You can" 
        })
        .GetByRole(AriaRole.Link, new() 
        { 
            Name = "trace.playwright.dev" 
        });
    }
}
