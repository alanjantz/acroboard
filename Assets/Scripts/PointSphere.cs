using UnityEngine;

public class PointSphere : MonoBehaviour
{
    private GameHandler _gameHandler;

    private void Awake()
    {
        _gameHandler = GameHandler.GetInstance();
    }

    public void OnLook()
    {
        GameManager.AddPoint();
        _gameHandler.RemovePoint(this.gameObject);
    }
}
