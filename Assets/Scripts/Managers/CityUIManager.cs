using UnityEngine;
using UnityEngine.EventSystems;

public class CityUIManager : MonoBehaviour
{
    public GameObject Pointer;
    public GameObject Menu;
    public GameObject MenuOptions;
    public GameObject MenuControllers;

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

        if (isPaused)
        {
            if (_state == CityUIMenuStates.Default)
                _state = CityUIMenuStates.Options;

            switch (_state)
            {
                case CityUIMenuStates.Controllers:
                    ShowControllers();
                    break;
                case CityUIMenuStates.Options:
                default:
                    ShowOptions();
                    break;
            }
        }
        else
        {
            _state = CityUIMenuStates.Default;
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    public void ShowOptions()
    {
        _state = CityUIMenuStates.Options;
        MenuOptions.SetActive(true);
        MenuControllers.SetActive(false);
        if (EventSystem.current.currentSelectedGameObject == null)
            EventSystem.current.SetSelectedGameObject(ResumeButton);
    }

    public void ShowControllers()
    {
        _state = CityUIMenuStates.Controllers;
        MenuOptions.SetActive(false);
        MenuControllers.SetActive(true);
    }
}
