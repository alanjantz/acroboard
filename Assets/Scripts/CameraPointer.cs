using UnityEngine;

public class CameraPointer : MonoBehaviour
{
    private GameObject _gazedObject = null;

    public void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit,
                            AcroboardConfiguration.PlayerViewMaxDistance))
        {
            if (_gazedObject != hit.transform.gameObject)
            {
                _gazedObject = hit.transform.gameObject;

                if (_gazedObject.CompareTag(Constants.PointSphereTag))
                    _gazedObject.SendMessage("OnLook");
            }
        }
        else
        {
            _gazedObject = null;
        }
    }
}

