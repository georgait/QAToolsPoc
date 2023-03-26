namespace QATools.Pattern;

public interface IActor
{
    string Name { get; }
    IReadOnlyCollection<IAbility> Abilities { get; }

    IAbility HasTheAbilityTo(IAbility ability);
    Task<T> WhoAsksFor<T>(IQuestion<T> question) where T : class;
    Task WhoAttemptsTo(ITask task);
}
