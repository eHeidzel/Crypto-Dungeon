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
        Image image = (Image)args[0];
        Sprite sprite = (Sprite)args[1];
        image.overrideSprite = sprite;
    }
}
