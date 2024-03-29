﻿namespace QATools.Steps;

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
                // options from appsettings.json (optional, default values are used if not provided)
            });

        await actor.WhoAttemptsTo(Navigate.To(Urls.DOC));
    }

    [When(@"(.*) searches for ""([^""]*)""")]
    public async Task WhenGeorgeSearchesFor(IActor actor, string text)
    {
        await actor.WhoAttemptsTo(Click.OnTarget(TopNavBar.SearchLabelBtn));

        await actor.WhoAttemptsTo(Enter.OnTarget(TopNavBar.SearchDocs).TheValue(text));
    }

    [Then(@"(.*) clicks on GetStarted button in homepage")]
    public async Task ThenGeorgeClicksOnGetStartedButtonInHomepage(IActor actor)
    {
        await actor.WhoAttemptsTo(Click.OnTarget(HomePage.GetStartedBtn));
    }

    [Then(@"(.*) navigates to trace viewer via sidebar")]
    public async Task ThenGeorgeNavigatesToTraceViewerViaSidebar(IActor actor)
    {
        await actor.WhoAttemptsTo(Click.OnTarget(SideNavBar.TraceViewerBtn));
    }

    [Then(@"(.*) asserts that the viewing trace cli command is ""([^""]*)""")]
    public async Task ThenGeorgeAssertsThatTheViewingTraceCliCommandIs(IActor actor, string command)
    {
        // 1. With Page object
        //var text1 = await actor.WhoAsksFor(TheText.OfTarget(TraceViewer.CliCommand));

        // 2. With Func
        var text = await actor.WhoAsksFor(TheText.OfTarget(page =>
        {
            return page.GetByRole(AriaRole.Code).Filter(new() { HasText = command }).First;
        }));        
        
        Assert.That(text == command, Is.True);
    }

    [Then(@"(.*) navigates to trace viewer static website")]
    public async Task ThenGeorgeNavigatesToTraceViewerStaticWebsite(IActor actor)
    {
        await actor.WhoAttemptsTo(OpenNewWindow.Named("TraceViewerStaticWebsite").UsingTarget(TraceView.Page));
    }
}

