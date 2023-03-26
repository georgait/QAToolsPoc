namespace QATools.Hooks;

[Binding]
public class Transformations
{
    private readonly IObjectContainer _container;

    public Transformations(IObjectContainer container)
    {
        _container = container;
    }

    [StepArgumentTransformation(@"(.*)")]
    public IActor GenerateActor(string actorName) 
    {
        return OnStage.UsingContainer(_container).GetActor(actorName);
    }  
}
