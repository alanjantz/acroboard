using UnityEngine;
using UnityEngine.InputSystem;

public class BaseVrScene : MonoBehaviour
{
    public bool HasController { get; private set; }

    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.brightness = 1.0f;

        OnStart();
    }

    private void Update()
    {
        if (Gamepad.all.Count < 1)
        {
            HasController = false;
            OnControllerConnectionLost();
        }
        else
        {
            HasController = true;
        }

        OnUpdate();
    }

    public virtual void OnStart() { }

    public virtual void OnUpdate() { }

    public virtual void OnControllerConnectionLost()
    {
#if UNITY_EDITOR
        Debug.LogError("Controller Connection Lost");
#endif
    }
}
