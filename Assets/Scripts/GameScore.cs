using UnityEngine;

public class GameScore : MonoBehaviour
{
    public static GameScore _instance;

    public static GameScore GetInstance() => _instance;

    public float currentPointValue = 5f;
    public float CurrentScore { get; private set; } = 0f;

    private SoundManager soundManager;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        soundManager = SoundManager.GetInstance();
    }

    public void AddPoint() => AddPoints(1);

    public void AddPoints(int amount)
    {
        CurrentScore += currentPointValue * amount;
        soundManager.PlaySound(Sounds.Point);
    }

    public void IncreasePoints(float newPoints) => currentPointValue += newPoints;
}
