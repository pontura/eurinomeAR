using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatLine : MonoBehaviour
{
    public Text title;
    public Text valueField;
    public Image progressImage;
    public float value;

    public void Init(string text, float defaultValue)
    {
        title.text = text;
        value = defaultValue;
    }
    public void SetValue(string fieldValue, float normalizedValue)
    {
        valueField.text = fieldValue;
        value = normalizedValue;
        progressImage.fillAmount = value;
    }
}
