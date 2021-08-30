using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoviment : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public GameObject platform;

    private float horizontalRotation;
    private float verticalRotation;

    private bool isUpPressed = false;
    private bool isDownPressed = false;

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
        isUpPressed = !isUpPressed;
    }

    void OnGoDown(InputValue input)
    {
        isDownPressed = !isDownPressed;
    }

    private void Move(float aux)
    {
        var platformPosition = aux * speed * Time.deltaTime * platform.transform.up;

        if (platformPosition.y + platform.transform.position.y > initialPosition)
        {
            platform.transform.position += platformPosition;

            controller.Move(transform.up * aux * speed * Time.deltaTime);
        }
    }

    void Update()
    {
        Vector3 move = transform.right * horizontalRotation + transform.forward * verticalRotation;

        controller.Move(speed * Time.deltaTime * move);

        if (isUpPressed)
            Move(1);
        else if (isDownPressed)
            Move(-1);
    }
}