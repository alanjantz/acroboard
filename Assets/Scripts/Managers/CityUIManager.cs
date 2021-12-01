using UnityEngine;
using UnityEngine.EventSystems;

public class CityUIManager : MonoBehaviour
{
    public GameObject Pointer;

    public GameObject Menu, Tutorial, MenuOptions, MenuControllers, MenuNoControllerConnected;
    public GameObject ResumeButton, ControllersButton, ExitButton;

    private CityUIMenuStates _state;
    public bool ShowedTutorial = false;

    private static CityUIManager _instance;
    public static CityUIManager GetInstance() => _instance;

    private void Start()
    {
        _state = CityUIMenuStates.Default;
        _instance = this;
    }

    void Update()
    {
        if (AcroboardConfiguration.Tutorial && !ShowedTutorial)
        {
            _state = CityUIMenuStates.Tutorial;
            GameManager.Pause();
        }

        ControlMenu();
        Pointer.SetActive(GameManager.Playing);
    }

    private void ControlMenu()
    {
        Menu.SetActive(GameManager.Paused);

        if (_state == CityUIMenuStates.Default)
            _state = CityUIMenuStates.Options;

        if (GameManager.Paused)
        {
            Tutorial.SetActive(_state == CityUIMenuStates.Tutorial);
            MenuOptions.SetActive(_state == CityUIMenuStates.Options);
            MenuControllers.SetActive(_state == CityUIMenuStates.Controllers);
            MenuNoControllerConnected.SetActive(_state == CityUIMenuStates.NoControllerConnected);
            if (EventSystem.current.currentSelectedGameObject == null)
                EventSystem.current.SetSelectedGameObject(ResumeButton);
        }
        else
        {
            _state = CityUIMenuStates.Default;
            Tutorial.SetActive(false);
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

    public void HideTutorial()
    {
        ShowedTutorial = true;
    }
}
