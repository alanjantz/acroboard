using TMPro;
using UnityEngine;

public class Blinker : MonoBehaviour
{
    GameObject obj;
    public TextMeshProUGUI Text;
    public float FadeInTime = 0.5f;
    public float StayTime = 0.8f;
    public float FadeOutTime = 0.7f;
    private float _timeChecker = 0f;
    private Color _color;

    private void Start()
    {
        _color = Text.color;
    }

    private void Update()
    {
        Blink();
    }

    private void Blink()
    {
        _timeChecker += Time.deltaTime;
        float alpha = 0;

        if (_timeChecker < FadeInTime)
            alpha = _timeChecker / FadeInTime;
        else if (_timeChecker < FadeInTime + StayTime)
            alpha = 1f;
        else if (_timeChecker < FadeInTime + StayTime + FadeOutTime)
            alpha = 1f - (_timeChecker - (FadeInTime + StayTime)) / FadeOutTime;
        else
            _timeChecker = 0f;

        Text.color = new Color(_color.r, _color.g, _color.b, alpha);
    }
}
