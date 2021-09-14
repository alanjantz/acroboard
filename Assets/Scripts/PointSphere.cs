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
        GameScore.GetInstance().AddPoint();
        _gameHandler.RemovePoint(this.transform.parent.gameObject);
    }
}
