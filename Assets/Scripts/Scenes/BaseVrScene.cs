using UnityEngine;

public class BaseVrScene : MonoBehaviour
{
    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.brightness = 1.0f;

        OnStart();
    }

    public virtual void OnStart() { }
}
