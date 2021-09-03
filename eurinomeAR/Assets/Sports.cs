using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sports : MonoBehaviour
{
    public VideogameNave nave;
    public VideogameObstacles obstacles;
    public VideogameUI ui;

    public states state;

    public VideogameStats stats;

    public enum states
    {
        IDLE,
        PLAYING,
        GAME_OVER
    }
    void Start()
    {
        InitPlaying();
        obstacles.Init(this);

    }
    void OnEnable()
    {
        Events.OnJoystickPressed += OnJoystickPressed;
        Events.ShowJoystick(true);
    }
    private void OnDisable()
    {
        Events.OnJoystickPressed -= OnJoystickPressed;
        Events.ShowJoystick(false);
    }
    public void Init()
    {
        InitPlaying();
    }
    void InitPlaying()
    {
        state = states.PLAYING;
    }
    void OnJoystickPressed()
    {
        nave.Fire();
    }
    public void OnGameOver()
    {
        obstacles.Reset();
        state = states.GAME_OVER;
    }

}
