namespace QATools.Steps;

[Binding]
public class PlaywrightSteps 
{    

    [Given(@"(.*) navigates to playwright docs")]
    public async Task NavigateTo_PlaywrightDocs(IActor actor)
    {
        await BrowseTheWeb
            .WithPlaywright()
            .AsActor(actor)
            .AsyncWith(Browsers.CHROMIUM, opt =>
            {
                // options from appsettings.json
            });
        
        await actor.WhoAttemptsTo(Navigate.To(Urls.DOC));
    }

    [When(@"(.*) searches for ""([^""]*)""")]
    public async Task WhenGeorgeSearchesFor(IActor actor, string text)
    {
        await actor.WhoAttemptsTo(Click.OnTarget().UsingDynamicLocator(TopNavBar.SearchLabelBtn));
        await actor.WhoAttemptsTo(Enter.TheValue(text).UsingDynamicLocator(TopNavBar.SearchDocs));
    }

    [Then(@"(.*) clicks on GetStarted button in homepage")]
    public async Task ThenGeorgeClicksOnGetStartedButtonInHomepage(IActor actor)
    {
        await actor.WhoAttemptsTo(Click.OnTarget().UsingDynamicLocator(HomePage.GetStartedBtn));
    }

    [Then(@"(.*) navigates to trace viewer via sidebar")]
    public async Task ThenGeorgeNavigatesToTraceViewerViaSidebar(IActor actor)
    {
        await actor.WhoAttemptsTo(Click.OnTarget().UsingDynamicLocator(SideNavBar.TraceViewerBtn));
    }

    [Then(@"(.*) asserts that the viewing trace cli command is ""([^""]*)""")]
    public async Task ThenGeorgeAssertsThatTheViewingTraceCliCommandIs(IActor actor, string command)
    {
        // 1. With Page object
        //var text = await actor.WhoAsksFor(TheText.OfLocator().Using(TraceViewer.CliCommand));
        
        // 2. With Func
        var text = await actor.WhoAsksFor(TheText.OfTarget().UsingDynamicLocator(page =>
        {
            return page.GetByRole(AriaRole.Code).Filter(new() { HasText = command + "a" }).First;
        }));        
        
        Assert.AreEqual(command, text);
    }

    [Then(@"(.*) navigates to trace viewer static website")]
    public async Task ThenGeorgeNavigatesToTraceViewerStaticWebsite(IActor actor)
    {
        await actor.WhoAttemptsTo(OpenNewWindow.Named("TraceViewerStaticWebsite").UsingDynamicLocator(TraceView.Page));
    }
}

