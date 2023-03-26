namespace QATools.Pages;
public static class SideNavBar
{
    public static ILocator TraceViewerBtn(IPage page)
    {
        return page.GetByRole(AriaRole.Listitem)
            .Filter(new() 
            { 
                HasText = "GuidesActionsAuto-waitingAPI testingAssertionsAuthenticationBrowsersDebugging Te" 
            }) 
            .GetByRole(AriaRole.Link, new() { Name = "Trace viewer" });
    }

    public static ILocator CodeGenBtn(IPage page)
    {
        return page.GetByRole(AriaRole.Listitem)
            .Filter(new() 
            { 
                HasText = "Getting StartedInstallationWriting testsRunning testsTest generatorTrace viewerT"
            }) 
            .GetByRole(AriaRole.Link, new() { Name = "Test generator" });
    }
}
