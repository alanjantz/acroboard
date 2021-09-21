using UnityEngine;
using UnityEngine.InputSystem;

public class CameraPointer : MonoBehaviour
{
    public Transform playerBody;

    public float sensitivity = 150f;

    private const float _maxDistance = 25f;
    private GameObject _gazedAtObject = null;

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

    public void Update()
    {
        // Fazer o objeto do player virar para a posição que ele está olhando
        // Para que ele ande na direção que olha
        // playerBody.LookAt(transform.forward);

#if UNITY_EDITOR
        Rotate();
#endif

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _maxDistance))
        {
            if (_gazedAtObject != hit.transform.gameObject)
            {
                _gazedAtObject = hit.transform.gameObject;

                if (_gazedAtObject.CompareTag(Constants.PointSphereTag))
                    _gazedAtObject.SendMessage("OnLook");
            }
        }
        else
        {
            _gazedAtObject = null;
        }
    }

    void Rotate()
    {
        float xAxis = horizontalRotation * sensitivity * Time.deltaTime;
        float yAxis = verticalRotation * sensitivity * Time.deltaTime;

        xRotation -= yAxis;

        if (xRotation <= -360f)
            xRotation = 0f;

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * xAxis);
    }
}
