using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoviment : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public GameObject platform;

    private float horizontalRotation;
    private float verticalRotation;

    private PlayerMovimentState state = PlayerMovimentState.StandingBy;

    private float initialPosition = 0f;

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

    PlayerMovimentState GetNewState(PlayerMovimentState newState)
        => state == newState ? PlayerMovimentState.StandingBy : newState;

    private void Move(float aux)
    {
        var platformPosition = aux * speed * Time.deltaTime * platform.transform.up;

        if (platformPosition.y + platform.transform.position.y > initialPosition)
        {
            platform.transform.position += platformPosition;

            controller.Move(transform.up * aux * speed * Time.deltaTime);
        }
        else if (state == PlayerMovimentState.Reseting)
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
                Move(1);
                break;
            case PlayerMovimentState.GoingDown:
            case PlayerMovimentState.Reseting:
                Move(-1);
                break;
            case PlayerMovimentState.StandingBy:
            default:
                break;
        }
    }
}