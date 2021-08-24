using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoviment : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    private float horizontalRotation;
    private float verticalRotation;

    void OnHorizontalMovement(InputValue input)
    {
        var value = input.Get<float>();

        Debug.Log($"OnHorizontalRotation: {value}");

        horizontalRotation = value;
    }

    void OnVerticalMovement(InputValue input)
    {
        var value = input.Get<float>();

        verticalRotation = value;
    }

    void Update()
    {
        Vector3 move = transform.right * horizontalRotation + transform.forward * verticalRotation;

        controller.Move(move * speed * Time.deltaTime);
    }
}
