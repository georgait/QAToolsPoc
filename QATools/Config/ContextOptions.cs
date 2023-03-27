namespace QATools.Config;

public class ContextOptions
{
    public ContextOptions()
    {
        BrowserTypes = new List<string>() 
        { 
            "chromium"
        };
    }

    public IEnumerable<string> BrowserTypes { get; set; } 
    public string RecordVideoDir { get; set; } = null;
    public bool TraceViewEnabledOnFailure { get; set; } = true;
    public bool Headless { get; set; } = true;
}
