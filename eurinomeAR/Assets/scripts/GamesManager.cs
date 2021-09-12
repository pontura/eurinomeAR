using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LeoLuz.PlugAndPlayJoystick;

public class GamesManager : MonoBehaviour
{
    public static GamesManager mInstance;
    public static GamesManager Instance
    {
        get { return mInstance; }
    }
    public GameObject joystickPanel;
    public AnalogicKnob analogicKnob;
    public TextsManager texts;

    private void Awake()
    {
        mInstance = this;
        joystickPanel.SetActive(false);
        Events.ShowJoystick += ShowJoystick;
    }
    void OnDestroy()
    {
        Events.ShowJoystick -= ShowJoystick;
    }
    void ShowJoystick(bool showIt)
    {
        joystickPanel.SetActive(showIt);
    }
    public void OnJoystickPressed()
    {
        Events.OnJoystickPressed();
    }
}
