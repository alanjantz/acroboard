using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Platform : MonoBehaviour
{
    private const float DEFAULT_MAX_HEIGHT = 80f;

    public GameObject heightInfo;
    public float maxHeight = DEFAULT_MAX_HEIGHT;

    public static float CurrentMaxHeight = DEFAULT_MAX_HEIGHT;
    public static float CurrentPlatformY { get; protected set; }
    public static double CurrentPlatformHeight => CurrentPlatformY.GetHeightValue();
    private PlayerMovimentState state = PlayerMovimentState.StandingBy;
    private float initialPosition = 0f;
    private const float divisor = 2.5f;

    private static Platform _instance;
    public static Platform GetInstance() => _instance;

    private void Awake()
    {
        initialPosition = transform.position.y;
    }

    private void Start()
    {
        CurrentMaxHeight = maxHeight;
        _instance = this;
    }

    private void OnGoUp(InputValue inputValue)
    {
        ControlTriggerAction(PlayerMovimentState.GoingUp, inputValue.Get<float>());
    }

    private void OnGoDown(InputValue inputValue)
    {
        ControlTriggerAction(PlayerMovimentState.GoingDown, inputValue.Get<float>());
    }

    private void ControlTriggerAction(PlayerMovimentState newState, float value)
    {
        if (value > 0)
            state = GetNewState(newState);
        else
            state = PlayerMovimentState.StandingBy;
    }

    private void OnReset()
    {
        state = GetNewState(PlayerMovimentState.Reseting);
    }

    private void OnGoToHighest()
    {
        state = GetNewState(PlayerMovimentState.GoingToHighest);
    }

    PlayerMovimentState GetNewState(PlayerMovimentState newState)
        => state == newState ? PlayerMovimentState.StandingBy : newState;

    private void GoUp(float limit)
    {
        Move(1, limit, (limit, next) => next <= limit);
    }

    private void GoDown(float limit)
    {
        Move(-1, limit, (limit, next) => next >= limit);
    }

    private void Move(int aux, float limit, Func<float, float, bool> comparison)
    {
        var platformPosition = aux * AcroboardConfiguration.PlatformVelocity * Time.deltaTime * transform.up;

        var nextHeight = platformPosition.y + transform.position.y;

        if (comparison(limit, nextHeight))
            transform.position += platformPosition;
        else
            state = PlayerMovimentState.StandingBy;
    }

    private void Update()
    {
        if (GameManager.Playing)
        {
            switch (state)
            {
                case PlayerMovimentState.GoingUp:
                case PlayerMovimentState.GoingToHighest:
                    GoUp(CurrentMaxHeight);
                    break;
                case PlayerMovimentState.GoingDown:
                case PlayerMovimentState.Reseting:
                    GoDown(initialPosition);
                    break;
                case PlayerMovimentState.StandingBy:
                default:
                    break;
            }

            CurrentPlatformY = transform.position.y;

            if (heightInfo != null)
                heightInfo.gameObject.transform.Find("Value").GetComponent<TextMeshPro>().text = $"{GetHeightValue(CurrentPlatformY.GetHeightValue())}m";
        }
    }

    public double GetHeightValue(double height)
    {
        float equivalentMaxHeight = CurrentMaxHeight / divisor;

        if (height >= equivalentMaxHeight - 0.5f)
            return Math.Ceiling(equivalentMaxHeight);

        return Math.Truncate(height);
    }

    public void StopPlatform()
    {
        state = PlayerMovimentState.StandingBy;
    }
}