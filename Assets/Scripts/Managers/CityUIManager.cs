using UnityEngine;
using UnityEngine.EventSystems;

public class CityUIManager : MonoBehaviour
{
    public GameObject Pointer;
    public GameObject Menu;
    public GameObject MenuOptions;
    public GameObject MenuControllers;
    public GameObject MenuNoControllerConnected;

    public GameObject ResumeButton, ControllersButton, ExitButton;
    private CityUIMenuStates _state;

    private static CityUIManager _instance;
    public static CityUIManager GetInstance() => _instance;

    private void Start()
    {
        _state = CityUIMenuStates.Default;
        _instance = this;
    }

    void Update()
    {
        var playing = GameManager.Playing;

        ControlMenu(!playing);
        Pointer.SetActive(playing);
    }

    private void ControlMenu(bool isPaused)
    {
        Menu.SetActive(isPaused);

        if (_state == CityUIMenuStates.Default)
            _state = CityUIMenuStates.Options;

        if (isPaused)
        {
            MenuOptions.SetActive(_state == CityUIMenuStates.Options);
            MenuControllers.SetActive(_state == CityUIMenuStates.Controllers);
            MenuNoControllerConnected.SetActive(_state == CityUIMenuStates.NoControllerConnected);
            if (EventSystem.current.currentSelectedGameObject == null)
                EventSystem.current.SetSelectedGameObject(ResumeButton);
        }
        else
        {
            _state = CityUIMenuStates.Default;
            MenuOptions.SetActive(false);
            MenuControllers.SetActive(false);
            MenuNoControllerConnected.SetActive(false);
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    public void Show(CityUIMenuStates menu)
    {
        _state = menu;
    }
}
