namespace QATools.Pattern;

public class OnStage
{
    private readonly IObjectContainer _container;

    public OnStage(IObjectContainer container)
    {
        _container = container;
    }

    public static OnStage UsingContainer(IObjectContainer container)
    {
        return new OnStage(container);
    }

    public IActor GetActor(string actorName)
    {
        var exists = _container.TryResolve<IActor>(actorName, out var actor);
        if (!exists)
        {
            actor = new Actor(actorName);
            _container.RegisterInstanceAs(actor, actorName);
        }
        return actor!;
    }
}
