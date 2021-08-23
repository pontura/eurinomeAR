using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorARButton : ARButton
{
    public Color color;
    public SpriteRenderer sr;

    public void SetColor(Color color)
    {
        sr.color = color;
        this.color = color;
    }
}
