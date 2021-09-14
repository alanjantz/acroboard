using UnityEngine;

public class CameraPointer : MonoBehaviour
{
    private const float _maxDistance = 25f;
    private GameObject _gazedAtObject = null;

    private PlayerLook _playerLook;

    private void Awake()
    {
        _playerLook = PlayerLook.GetInstance();
    }

    public void Update()
    {
        // Fazer o objeto do player virar para a posição que ele está olhando
        // _playerLook.playerBody.Rotate(transform.forward);

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _maxDistance))
        {
            if (_gazedAtObject != hit.transform.gameObject)
            {
                _gazedAtObject = hit.transform.gameObject;

                if (_gazedAtObject.CompareTag(Constants.PointSphereTag))
                    _gazedAtObject.SendMessage("OnRemove");
            }
        }
        else
        {
            _gazedAtObject = null;
        }
    }
}
