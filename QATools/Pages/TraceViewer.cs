namespace QATools.Pages;

public static class TraceViewer
{
    public static ILocator CliCommand(IPage page)
    {
        return page.GetByRole(AriaRole.Code).Filter(new() { HasText = "pwsh bin/Debug/netX/playwright.ps1 show-trace trace.zip" }).First;
    }
}
