using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Platform : MonoBehaviour
{
    public GameObject heightInfo;
    public float Speed = 12f;

    public static float MaxHeight = 80;
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
        var platformPosition = aux * Speed * Time.deltaTime * transform.up;

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
                    GoUp(MaxHeight);
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
            heightInfo.gameObject.transform.Find("Value").GetComponent<TextMeshPro>().text = $"{GetHeightValue(CurrentPlatformY.GetHeightValue())}m";
        }
    }

    public double GetHeightValue(double height)
    {
        float equivalentMaxHeight = MaxHeight / divisor;

        if (height >= equivalentMaxHeight - 0.5f)
            return Math.Ceiling(equivalentMaxHeight);

        return Math.Truncate(height);
    }

    public void StopPlatform()
    {
        state = PlayerMovimentState.StandingBy;
    }
}