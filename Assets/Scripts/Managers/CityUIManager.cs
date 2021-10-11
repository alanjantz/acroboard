using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CityUIManager : MonoBehaviour
{
    public GameObject Pointer;
    public GameObject Menu;

    private Image _background;
    public GameObject resumeButton, controllersButton, exitButton;

    void Start()
    {
        _background = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        ControlMenu(GameHandler.IsPaused);
        Pointer.SetActive(!GameHandler.IsPaused);
    }

    private void ControlMenu(bool isPaused)
    {
        float alpha = 0f;
        var originalColor = _background.color;

        Menu.SetActive(isPaused);
        if (isPaused)
        {
            alpha = 0.75f;
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                EventSystem.current.SetSelectedGameObject(resumeButton);
            }
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null);
        }

        _background.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
    }
}