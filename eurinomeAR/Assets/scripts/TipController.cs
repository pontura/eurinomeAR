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
        INITIAL_TIP,
        MUSIC_1,
        MUSIC_2,
        MUSIC_3,
        INTRO,
        RITMO_SPORTS
    }
    private void Awake()
    {
        panel.SetActive(false);
    }
    private void OnEnable()
    {
        if(type == types.INTRO)
        {
            panel.SetActive(false);
            Invoke("ShowIntro", 2);
        }
    }
    void ShowIntro()
    {
        print("ShowIntro");
        OnTip(TipController.types.INTRO, GamesManager.Instance.texts.GetText("WELCOME_TO_GAME"), true);
    }
    void Start()
    {
        Events.OnTip += OnTip;
        Events.OnTipTimout += OnTipTimout;
    }
    void OnDestroy()
    {
        Events.OnTip -= OnTip;
        Events.OnTipTimout -= OnTipTimout;
    }
    void OnTip(types _type, string text, bool isOn)
    {
        if (type == _type)
            ShowTip(text, isOn);
    }
    void ShowTip(string text, bool isOn)
    {
        field.text = text;
        panel.SetActive(isOn);
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
    private void OnDisable()
    {
        CancelInvoke();
    }
    void Reset()
    {
        panel.SetActive(false);
    }
}
