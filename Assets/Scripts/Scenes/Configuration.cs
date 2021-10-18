public class Configuration : BaseVrScene
{
    public void ResetConfigurations()
    {
        AcroboardConfiguration.Reset();
    }

    public void Return()
    {
        LoaderManager.Load(GameScene.Main, true);
    }
}
