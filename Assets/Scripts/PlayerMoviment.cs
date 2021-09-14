using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoviment : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public GameObject platform;
    public GameObject heightInfo;

    private float horizontalRotation;
    private float verticalRotation;

    private PlayerMovimentState state = PlayerMovimentState.StandingBy;

    private float initialPosition = 0f;
    public float maxHeight = 80;

    private void Awake()
    {
        initialPosition = platform.transform.position.y;
    }

    void OnHorizontalMovement(InputValue input)
    {
        var value = input.Get<float>();

        horizontalRotation = value;
    }

    void OnVerticalMovement(InputValue input)
    {
        var value = input.Get<float>();

        verticalRotation = value;
    }

    void OnGoUp(InputValue input)
    {
        state = GetNewState(PlayerMovimentState.GoingUp);
    }

    void OnGoDown(InputValue input)
    {
        state = GetNewState(PlayerMovimentState.GoingDown);
    }

    void OnReset(InputValue input)
    {
        state = GetNewState(PlayerMovimentState.Reseting);
    }

    void OnGoToHighest(InputValue input)
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
        var platformPosition = aux * speed * Time.deltaTime * platform.transform.up;

        var nextHeight = platformPosition.y + platform.transform.position.y;

        if (comparison(limit, nextHeight))
        {
            platform.transform.position += platformPosition;

            controller.Move(aux * speed * Time.deltaTime * transform.up);
        }
        else
        {
            state = PlayerMovimentState.StandingBy;
        }
    }

    void Update()
    {
        Vector3 move = transform.right * horizontalRotation + transform.forward * verticalRotation;

        controller.Move(speed * Time.deltaTime * move);

        switch (state)
        {
            case PlayerMovimentState.GoingUp:
            case PlayerMovimentState.GoingToHighest:
                GoUp(maxHeight);
                break;
            case PlayerMovimentState.GoingDown:
            case PlayerMovimentState.Reseting:
                GoDown(initialPosition);
                break;
            case PlayerMovimentState.StandingBy:
            default:
                break;
        }

        heightInfo.gameObject.transform.Find("Value").GetComponent<TextMeshPro>().text = $"{GetHeightValue()}m";
    }

    private double GetHeightValue()
    {
        float divisor = 2.5f;
        float equivalentMaxHeight = maxHeight / divisor;

        var result = platform.transform.position.y / divisor;

        if (result >= equivalentMaxHeight - 0.5f)
            return Math.Ceiling(equivalentMaxHeight);

        return Math.Truncate(result);
    }
}