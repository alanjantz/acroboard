public class CityScenario : BaseVrScene
{
    public override void OnUpdate()
    {
        base.OnUpdate();

        GameHandler.GetInstance().HasController = HasController;
    }
}
