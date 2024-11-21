using System;
using UnityEngine;
using UnityEngine.UI;

public class Slider : MonoBehaviour
{
    [SerializeField] private Sprite[] _slides;
    [SerializeField] private Image _slideImage;
    
    private int _slideIndex;
    private int slideIndex
    {
        get => _slideIndex;
        set
        {
            if (value < 0)
                _slideIndex = 0;
            else if (value > _slides.Length - 1)
                _slideIndex = _slides.Length - 1;
            else
                _slideIndex = value;
        }
    }

    private void Start()
    {
        ShowSprite(slideIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            slideIndex++;
            ShowSprite(slideIndex);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            slideIndex--;
            ShowSprite(slideIndex);
        }
    }

    private void ShowSprite(int index)
    {
        _slideImage.overrideSprite = _slides[index];
    }
}
