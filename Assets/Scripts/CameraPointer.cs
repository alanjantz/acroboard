using UnityEngine;

public class CameraPointer : MonoBehaviour
{
    private GameObject _gazedObject = null;

    public void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, AcroboardConfiguration.PlayerViewMaxDistance))
        {
            if (_gazedObject != hit.transform.gameObject)
            {
                _gazedObject = hit.transform.gameObject;

                ControlGameActions(_gazedObject);
            }
        }
        else
        {
            _gazedObject = null;
        }
    }

    private void ControlGameActions(GameObject gazedObject)
    {
        if (GameManager.Playing)
        {
            if (gazedObject.CompareTag(Constants.PointSphereTag))
                gazedObject.SendMessage("OnLook");
        }
    }
}
