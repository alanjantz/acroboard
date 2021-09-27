using UnityEngine;

public class GameScoreHandler : MonoBehaviour
{
    public static GameScoreHandler _instance;

    public static GameScoreHandler GetInstance() => _instance;

    public float currentPointValue = 5f;
    public float CurrentScore { get; private set; } = 0f;

    private void Start()
    {
        _instance = this;
    }

    public void AddPoint() => AddPoints(1);

    public void AddPoints(int amount)
    {
        CurrentScore += currentPointValue * amount;
        SoundHandler.GetInstance().PlaySound(Sounds.Point);
    }

    public void IncreasePoints(float newPoints) => currentPointValue += newPoints;
}
