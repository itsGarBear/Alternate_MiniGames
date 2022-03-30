using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterController : MonoBehaviour
{
    private Image image;
    private Text text;
    public Controls control;
    private ColorState currColorState = ColorState.None;

    private void Awake()
    {
        image = GetComponent<Image>();
        text = GetComponentInChildren<Text>();
    }

    public string GetLetter()
    {
        return text.text.ToLowerInvariant();
    }

    public void EnterLetter()
    {
        control.EnterLetter(this);
    }

    public void ChangeColorControl(Color inputColor)
    {
        Color colorToChange;
        if (currColorState == ColorState.None)
        {
            if (ColorCollection.Green.Equals(inputColor))
            {
                currColorState = ColorState.Green;
                colorToChange = ColorCollection.Green;
            }
            else if (ColorCollection.Yellow.Equals(inputColor))
            {
                currColorState = ColorState.Yellow;
                colorToChange = ColorCollection.Yellow;
            }
            else
            {
                currColorState = ColorState.Grey;
                colorToChange = ColorCollection.Grey;
            }
        }
        else if (currColorState == ColorState.Green || ColorCollection.Green.Equals(inputColor))
        {
            colorToChange = ColorCollection.Green;
            currColorState = ColorState.Green;
        }
        else if (currColorState == ColorState.Yellow || ColorCollection.Yellow.Equals(inputColor))
        {
            colorToChange = ColorCollection.Yellow;
            currColorState = ColorState.Yellow;
        }
        else
        {
            colorToChange = ColorCollection.Grey;
            currColorState = ColorState.Grey;
        }
    }

    private enum ColorState
    {
        Green,
        Yellow,
        Grey,
        None
    }
}
