namespace QATools.Pattern;

public sealed class BrowseTheWeb : IAbility
{
    private readonly ContextOptions _contextOptions;

    private IPlaywright _playwright;
    private IBrowser _browser;
    private IBrowserContext _ctx;
    private IPage _page;
    private readonly IDictionary<string, IPage> _innerPages;

    public IActor Actor { get; private set; }

    BrowseTheWeb()
    {
        _contextOptions = new();
        _innerPages = new Dictionary<string, IPage>();
    }

    public static BrowseTheWeb WithPlaywright()
    {
        return new BrowseTheWeb();
    }

    public static IAbility As(IActor actor)
    {
        var browseTheWeb = actor.Abilities.FirstOrDefault(a => a is BrowseTheWeb);
        return browseTheWeb;
    }
    
    public BrowseTheWeb AsActor(IActor actor) 
    {
        Actor = actor;
        return this;
    }

    public async Task<BrowseTheWeb> AsyncWith(
        Browsers browserType,
        Action<ContextOptions> options = null!)
    {
        options?.Invoke(_contextOptions);

        if (_page is null)
        {
            _playwright = await Playwright.CreateAsync();

            await SelectBrowserType(browserType);

            await AddNewContextAsync();

            await AddTraceViewOrDefaultAsync();

            _page = await _ctx.NewPageAsync();

            Actor.HasTheAbilityTo(this);
        }

        return this;
    }

    public IPage GetCurrentPage()
    {
        if (_page is null) 
            throw new NullPageException();

        return _page;
    }

    public async Task<IPage> WithChildPage(string name, Func<Task> action)
    {
        if (_page is null)
            throw new NullPageException();

        var innerPage = await _page.RunAndWaitForPopupAsync(action);
        _innerPages.Add(name, innerPage);
        return innerPage;
    }

    public IPage GetChildPage(string name) { return _innerPages[name]; }

    public async Task StopAndExportTraceIfEnabled(string path = "trace.zip")
    {
        if (_ctx is not null && _contextOptions.TraceViewEnabledOnFailure)
        {
            await _ctx.Tracing.StopAsync(new()
            {
                Path = path
            });
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_page is not null)
            await _page.CloseAsync();

        if (_ctx is not null)
        {
            await _ctx.CloseAsync();
            await _ctx.DisposeAsync();
        }
        
        if(_browser is not null) 
            await _browser.DisposeAsync();

        _playwright!?.Dispose();
    }

    private async Task SelectBrowserType(Browsers browserType)
    {
        switch (browserType)
        {
            case Browsers.CHROMIUM:
                _browser = await _playwright!.Chromium.LaunchAsync(new() { Headless = _contextOptions.Headless })!;
                break;
            case Browsers.FIREFOX:
                _browser = await _playwright!.Firefox.LaunchAsync(new() { Headless = _contextOptions.Headless });
                break;
            case Browsers.WEBKIT:
                _browser = await _playwright!.Webkit.LaunchAsync(new() { Headless = _contextOptions.Headless });
                break;
        }
    }

    private async ValueTask AddNewContextAsync()
    {
        if (!string.IsNullOrEmpty(_contextOptions.RecordVideoDir))
        {
            _ctx = await _browser!.NewContextAsync(new()
            {
                RecordVideoDir = _contextOptions.RecordVideoDir
            });
        }
        else
        {
            _ctx = await _browser!.NewContextAsync();
        }
    }

    private async Task AddTraceViewOrDefaultAsync()
    {
        if (_contextOptions.TraceViewEnabledOnFailure)
        {
            // Start tracing before creating / navigating a page.
            await _ctx.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });
        }
    }   
}