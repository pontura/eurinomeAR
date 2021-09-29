using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LeoLuz.PlugAndPlayJoystick;
using Vuforia;
using UnityEngine.XR;

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
    public ConfigPanel configs;
    public VuforiaBehaviour vuforiaBehavior;
    public Particlescontainer particlesContainer;

    public enum states
    {
        INTRO,
        RA,
        END
    }
    public states state;

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
    public void SetVuforiaOn(bool isOn)
    {
        vuforiaBehavior.enabled = isOn;
    }
    public void Reset()
    {
        foreach (ArExperience are in configs.games)
            are.Reset();
    }
}
