using UnityEngine;

public class CameraPointer : MonoBehaviour
{
    private GameObject _gazedAtObject = null;

    public void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, AcroboardConfiguration.PlayerViewMaxDistance))
        {
            if (_gazedAtObject != hit.transform.gameObject)
            {
                _gazedAtObject = hit.transform.gameObject;

                ControlGameActions(_gazedAtObject);
            }
        }
        else
        {
            _gazedAtObject = null;
        }
    }

    private void ControlGameActions(GameObject gazedAtObject)
    {
        if (GameManager.Playing)
        {
            if (gazedAtObject.CompareTag(Constants.PointSphereTag))
                gazedAtObject.SendMessage("OnLook");
        }
    }
}
