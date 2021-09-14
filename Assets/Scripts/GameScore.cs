using UnityEngine;

public class GameScore : MonoBehaviour
{
    public static GameScore _instance;

    public static GameScore GetInstance() => _instance;

    public float currentPointValue = 5f;
    public float CurrentScore { get; private set; } = 0f;

    private void Awake()
    {
        _instance = this;
    }

    public void AddPoint() => AddPoints(1);

    public void AddPoints(int amount) => CurrentScore += currentPointValue * amount;

    public void IncreasePoints(float newPoints) => currentPointValue += newPoints;
}
