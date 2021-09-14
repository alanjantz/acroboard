using System;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private static GameHandler _instance;

    public static GameHandler GetInstance() => _instance;

    public GameObject PointSphere;

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

    private void Start()
    {
        var firstLevel = new Level(gameStartedTime.AddSeconds(secondsInterval));
        firstLevel.Add(new Vector3(1, 6, 45));
        firstLevel.Add(new Vector3(1, 6, 20));
        levels.Enqueue(firstLevel);

        var secondLevel = new Level();
        secondLevel.Add(new Vector3(-10, 6, 30));
        secondLevel.Add(new Vector3(10, 6, 30));
        levels.Enqueue(secondLevel);
    }

    private void Update()
    {
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

                    _stage++;

                    Debug.Log($"LEVEL {_stage}");
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
        }
        else
        {
            Debug.Log($"--- LEVEL {_stage} ENDED ---");
            Debug.Log($"Points {GameScore.GetInstance().CurrentScore}");
        }
    }

    public void RemovePoint(GameObject point)
    {
        pointSpheres.Remove(point);
        Destroy(point);
    }
}
