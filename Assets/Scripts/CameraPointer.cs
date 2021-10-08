using UnityEngine;

public class CameraPointer : MonoBehaviour
{
    public float sensitivity = 150f;

    private const float _maxDistance = 25f;
    private GameObject _gazedAtObject = null;

    public void Update()
    {
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
}
