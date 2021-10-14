using UnityEngine.SceneManagement;

public static class LoaderManager
{
    private static GameScene _targetScene;
    public static GameScene CurrentScene { get; set; }

    public static void Reload()
    {
        Load(CurrentScene);
    }

    public static void Load(GameScene scene, bool straightThrough = false)
    {
        CurrentScene = scene;
        if (straightThrough)
            SceneManager.LoadScene(scene.GetStringValue());
        else
        {
            SceneManager.LoadScene(GameScene.Loading.GetStringValue());

            _targetScene = scene;
        }
    }

    public static void LoadTargetScene()
    {
        SceneManager.LoadScene(_targetScene.GetStringValue());
    }
}
