namespace QATools.Hooks;

[Binding]
public class Hooks
{
    [BeforeTestRun]
    public static void SetConfiguration(IObjectContainer container)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
            .AddEnvironmentVariables()
            .Build();

        container.RegisterInstanceAs<IConfiguration>(config);
    }

    [AfterScenario]
    public async Task Cleanup(IObjectContainer container)
    {
        var actors = container.ResolveAll<IActor>().ToList();
        foreach (var actor in actors)
        {
            var abilities = actor.Abilities.ToList();
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed) 
            {
                var browseTheWeb = abilities.FirstOrDefault(a => a is BrowseTheWeb) as BrowseTheWeb;
                await browseTheWeb.StopAndExportTraceIfEnabled();
            }
            abilities.ForEach(async ability =>
            {
                if (ability is BrowseTheWeb)
                {
                    await ability.DisposeAsync();
                }
            });
        }
    }
}
