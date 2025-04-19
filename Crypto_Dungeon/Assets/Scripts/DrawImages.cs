using UnityEngine;
using UnityEngine.UI;

public class DrawImages : MonoBehaviour
{
    [SerializeField] int index;
    [SerializeField] private Sprite[] draws;
    [SerializeField] private Image image;

    void Start() => image.overrideSprite = draws[index];
}
