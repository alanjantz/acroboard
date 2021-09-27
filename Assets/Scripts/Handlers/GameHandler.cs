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
    private int secondsInterval;
    private bool gameEnded;

    private bool reportFileCreated = false;

    public GameHandler()
    {
        levels = LevelGenerator.Genetare();
    }

    private void Awake()
    {
        secondsInterval = 5;
        _instance = this;
        ReportManager.CreateReport(levels.Count);
    }

    private void Update()
    {
        string currentLevel = "Total de pontos";

        if (gameEnded)
        {
            if (!reportFileCreated)
            {
                FileManager.CreateReportFile(ReportManager.GetCurrentReport());
                reportFileCreated = true;
            }
        }
        else
        {
            if (pointSpheres.Count == 0)
            {
                ReportManager.EndLevel(DateTime.Now);

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

                    ReportManager.AddLevel(_currentLevel);
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

            currentLevel = $"Nível {_stage}";
        }

        levelInfo.SetTextMeshProValue(currentLevel, "Label");
        levelInfo.SetTextMeshProValue(GameScoreHandler.GetInstance().CurrentScore.ToString());
    }

    public void RemovePoint(GameObject point)
    {
        ReportManager.AddPoint();
        pointSpheres.Remove(point);
        Destroy(point);
    }
}
