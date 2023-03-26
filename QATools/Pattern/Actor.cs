namespace QATools.Pattern;

public record Actor : IActor
{
    private readonly HashSet<IAbility> _abilities = new();

    public Actor(string name = "")
    {
        Name = name;
    }

    public string Name { get; private set; }

    public IReadOnlyCollection<IAbility> Abilities => _abilities;

    public IAbility HasTheAbilityTo(IAbility ability)
    {
        _abilities.Add(ability);
        return ability;
    }

    public async Task WhoAttemptsTo(ITask task)
    {
        await task.PerformTaskAsyncAs(this);
    }

    public async Task<T> WhoAsksFor<T>(IQuestion<T> question)
        where T : class
    {
        return await question.AskAsyncAs(this);
    }
}
