using UnityEngine;
using UnityEngine.InputSystem;

public class MovementHandler : MonoBehaviour
{
    private float _sensitivity = 150f;

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
        if (GameManager.Playing)
        {
            Move();
#if (!UNITY_IPHONE && !UNITY_ANDROID && !UNITY_IOS)
            Rotate();
#endif
        }
    }

    private void Move()
    {
        var direction = new Vector3(horizontalMovement, 0, verticalMovement);
        var velocity = direction * AcroboardConfiguration.PlayerVelocity;

        velocity = Camera.main.transform.TransformDirection(velocity);
        controller.Move(velocity * Time.deltaTime);
        controller.transform.position = new Vector3(controller.transform.position.x, Platform.CurrentPlatformY + originalPlayerHeight, controller.transform.position.z); ;
    }

    private void Rotate()
    {
        float xAxis = horizontalRotation * _sensitivity * Time.deltaTime;
        float yAxis = verticalRotation * _sensitivity * Time.deltaTime;

        xRotation -= yAxis;

        if (xRotation <= -360f)
            xRotation = 0f;

        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        controller.transform.Rotate(Vector3.up * xAxis);
    }
}
