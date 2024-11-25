using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EasterEggsActions : MonoBehaviour
{
    /// <summary>
    /// Needs object array that contains 2 args: UI Image where render and Sprite to render
    /// </summary>
    /// <param name="args"></param>
    public void ShowDota(Object[] args)
    {
        Image image = args[0].GetComponent<Image>();
        Sprite sprite = (Sprite)args[1];
        image.overrideSprite = sprite;
    }
}
