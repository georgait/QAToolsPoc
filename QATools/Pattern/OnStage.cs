namespace QATools.Pattern;

public class OnStage
{
    private readonly IObjectContainer _container;

    OnStage(IObjectContainer container)
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
            _container.RegisterInstanceAs(new Actor(actorName), actorName);
        }
        return actor!;
    }
}
