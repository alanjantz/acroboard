using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 150f;

    public Transform playerBody;

    private float horizontalRotation;
    private float xRotation = 0f;
    private float verticalRotation;

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

    void Update()
    {
        float xAxis = horizontalRotation * mouseSensitivity * Time.deltaTime;
        float yAxis = verticalRotation * mouseSensitivity * Time.deltaTime;

        xRotation -= yAxis;

        if (xRotation <= -360f)
            xRotation = 0f;

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * xAxis);
    }
}
