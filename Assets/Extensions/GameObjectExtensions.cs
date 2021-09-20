using TMPro;
using UnityEngine;

public static class GameObjectExtensions
{
    public static void SetTextMeshProValue(this GameObject gameObject, string value, string name = "Value")
    {
        gameObject.transform.Find(name).GetComponent<TextMeshPro>().text = value;
    }
}
