﻿using QATools.Questions;

namespace ScreenPlaywright.Steps;

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
        await actor.WhoAttemptsTo(Click.OnLocator().Using(TopNavBar.SearchLabelBtn));
        await actor.WhoAttemptsTo(Enter.TheValue(text).Using(TopNavBar.SearchDocs));
    }

    [Then(@"(.*) clicks on GetStarted button in homepage")]
    public async Task ThenGeorgeClicksOnGetStartedButtonInHomepage(IActor actor)
    {
        await actor.WhoAttemptsTo(Click.OnLocator().Using(HomePage.GetStartedBtn));
    }

    [Then(@"(.*) navigates to trace viewer via sidebar")]
    public async Task ThenGeorgeNavigatesToTraceViewerViaSidebar(IActor actor)
    {
        await actor.WhoAttemptsTo(Click.OnLocator().Using(SideNavBar.TraceViewerBtn));
    }

    [Then(@"(.*) asserts that the viewing trace cli command is ""([^""]*)""")]
    public async Task ThenGeorgeAssertsThatTheViewingTraceCliCommandIs(IActor actor, string command)
    {
        var text = await actor.WhoAsksFor(TheText.OfLocator().Using(TraceViewer.CliCommand));
        Assert.AreEqual(command, text);
    }

    [Then(@"(.*) navigates to trace viewer static website")]
    public async Task ThenGeorgeNavigatesToTraceViewerStaticWebsite(IActor actor)
    {
        await actor.WhoAttemptsTo(OpenNewWindow.Named("TraceViewerStaticWebsite").Using(TraceView.Page));
    }
}

