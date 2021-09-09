using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorUIButton : PartUIButton
{
    public Color color;

    public void Init(int id, System.Action<int> Clicked)
    {
        base.Init(id, Clicked, null);
    }
    public void SetColor(Color color)
    {
        image.color = color;
        this.color = color;
    }
}
