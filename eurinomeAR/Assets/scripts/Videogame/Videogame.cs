using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Videogame : GameMain
{
    public VideogameNave nave;
    public VideogameObstacles obstacles;
    public VideogameUI ui;

    public states state;

    public VideogameStats stats;
    public GameObject IntroPanel;

    public enum states
    {
        IDLE,
        PLAYING,
        GAME_OVER
    }
    public override void Reset()
    {
        base.Reset();
    }
    public void InitGame()
    {
        Events.OnTip(TipController.types.PLAY_BUTTON, "", false);
        Events.OnTipTimout(TipController.types.JOYSTICK, "Usa para moverte", 3);
        nave.Init();
        IntroPanel.SetActive(false);
        InitPlaying();
        obstacles.Init(this);
        Events.PlaySound("music", "naveMusic", true);
    }
    void Intro()
    {
        IntroPanel.SetActive(true);
        Events.PlaySound("music", "", true);
        Events.OnTip(TipController.types.PLAY_BUTTON, "Apretá para jugar!", true);
    }
    void OnEnable()
    {
       // Events.OnJoystickPressed += OnJoystickPressed;
        Events.ShowJoystick(true);
        Invoke("Delayed", 0.5f);
    }
    void Delayed()
    {
        Events.OnTip(TipController.types.PLAY_BUTTON, "Apretá para jugar!", true);
    }
    private void OnDisable()
    {
      //  Events.OnJoystickPressed -= OnJoystickPressed;
        Events.ShowJoystick(false);
    }
    void Init()
    {
        InitPlaying();
    }
    void InitPlaying()
    {
        state = states.PLAYING;
        Invoke("Tip", 8);
    }
    void Tip()
    {
        CancelInvoke();
        Events.OnTipTimout(TipController.types.NAVE_LEVELS, "Usa estos botones para cambiar de nivel!", 4);
    }
    public void OnJoystickPressed()
    {
        if (state == states.PLAYING)
            nave.Fire();
        else if (state == states.IDLE)
            InitGame();
        Events.OnTip(TipController.types.PLAY_BUTTON, "", false);
    }
    public void OnGameOver()
    {
        CancelInvoke();
        Events.PlaySound("music", "", true);
        obstacles.Reset();
        state = states.GAME_OVER;        
    }
    public void Restart()
    {
        state = states.IDLE;
        Intro();
    }


}
