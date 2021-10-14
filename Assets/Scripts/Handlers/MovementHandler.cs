using UnityEngine;
using UnityEngine.InputSystem;

public class MovementHandler : MonoBehaviour
{
    private float sensitivity = 150f;

    private float xRotation;
    private float horizontalRotation;
    private float verticalRotation;
    private float horizontalMovement;
    private float verticalMovement;

    private CharacterController controller;
    private float originalPlayerHeight;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        originalPlayerHeight = controller.transform.position.y;
    }

    void OnHorizontalRotation(InputValue input)
    {
        var value = input.Get<float>();

        horizontalRotation = value;
    }

    void OnVerticalRotation(InputValue input)
    {
        var value = input.Get<float>();

        verticalRotation = value;
    }

    void OnHorizontalMovement(InputValue input)
    {
        var value = input.Get<float>();

        horizontalMovement = value;
    }

    void OnVerticalMovement(InputValue input)
    {
        var value = input.Get<float>();

        verticalMovement = value;
    }

    void Update()
    {
        if (!GameHandler.IsPaused)
        {
            Move();
#if UNITY_EDITOR
            Rotate();
#endif
        }
    }

    private void Move()
    {
        var direction = new Vector3(horizontalMovement, 0, verticalMovement);
        var velocity = direction * GameHandler.GetInstance().Speed;

        velocity = Camera.main.transform.TransformDirection(velocity);
        controller.Move(velocity * Time.deltaTime);
        controller.transform.position = new Vector3(controller.transform.position.x, Platform.CurrentPlatformY + originalPlayerHeight, controller.transform.position.z); ;
    }

    private void Rotate()
    {
        float xAxis = horizontalRotation * sensitivity * Time.deltaTime;
        float yAxis = verticalRotation * sensitivity * Time.deltaTime;

        xRotation -= yAxis;

        if (xRotation <= -360f)
            xRotation = 0f;

        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        controller.transform.Rotate(Vector3.up * xAxis);
    }
}
