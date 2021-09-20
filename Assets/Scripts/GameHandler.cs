using System;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private static GameHandler _instance;

    public static GameHandler GetInstance() => _instance;

    public GameObject PointSphere;
    public GameObject levelInfo;

    private readonly Queue<Level> levels = new Queue<Level>();

    public readonly List<GameObject> pointSpheres = new List<GameObject>();
    private Level _currentLevel;
    private int _stage = 0;
    private DateTime gameStartedTime;
    private int secondsInterval;
    private bool gameEnded;

    private void Awake()
    {
        gameStartedTime = DateTime.Now;
        secondsInterval = 5;
        _instance = this;
    }

    public GameHandler()
    {
        levels = LevelGenerator.Genetare(gameStartedTime.AddSeconds(secondsInterval));
    }

    private void Update()
    {
        string currentLevel = "Total de pontos";

        if (!gameEnded)
        {
            if (pointSpheres.Count == 0)
            {
                if (_currentLevel == null)
                {
                    if (levels.Count == 0)
                    {
                        gameEnded = true;
                        return;
                    }

                    _currentLevel = levels.Dequeue();
                    if (!_currentLevel.StartTime.HasValue)
                        _currentLevel.SetStartTime(DateTime.Now.AddSeconds(secondsInterval));

                    _stage = _currentLevel.Stage;
                }

                if (_currentLevel.StartTime.GetValueOrDefault() <= DateTime.Now)
                {
                    for (int i = 0; i < _currentLevel.Positions.Count; i++)
                    {
                        var point = Instantiate(PointSphere, _currentLevel.Positions[i], Quaternion.identity);
                        point.name = $"Point Sphere {i + 1}";
                        pointSpheres.Add(point);
                    }

                    _currentLevel = null;
                }
            }

            currentLevel = $"Nível {_stage} ({pointSpheres.Count})";
        }

        levelInfo.SetTextMeshProValue(currentLevel, "Label");
        levelInfo.SetTextMeshProValue(GameScore.GetInstance().CurrentScore.ToString());
    }

    public void RemovePoint(GameObject point)
    {
        pointSpheres.Remove(point);
        Destroy(point);
    }
}
