using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipController : MonoBehaviour
{
    public GameObject panel;
    public types type;
    public Text field;
    public enum types
    {
        PLAY_BUTTON,
        JOYSTICK,
        NAVE_LEVELS,
        INITIAL_TIP
    }
    private void Awake()
    {
        panel.SetActive(false);
    }
    void Start()
    {
        Events.OnTip += OnTip;
        Events.OnTipTimout += OnTipTimout;
    }
    void OnTip(types _type, string text, bool isOn)
    {
        if (type == _type)
        {
            field.text = text;
            panel.SetActive(isOn);
        }
        Events.PlaySound("ui", "tip", false);
    }
    void OnTipTimout(types _type, string text, int timer)
    {
        if (type == _type)
        {
            panel.SetActive(true);
            field.text = text;
            Invoke("Reset", timer);
        }
        Events.PlaySound("ui", "tip", false);
    }
    void Reset()
    {
        panel.SetActive(false);
    }
}
