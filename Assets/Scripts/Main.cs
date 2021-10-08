using UnityEngine;

public class Main : MonoBehaviour
{
    public void StartGame()
    {
        LoaderManager.Load(GameScene.City);
    }
}
