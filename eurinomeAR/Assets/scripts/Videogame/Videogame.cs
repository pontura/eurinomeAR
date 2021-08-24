using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Videogame : MonoBehaviour
{
    public VideogameNave nave;
    public VideogameObstacles obstacles;
    public VideogameUI ui;

    public states state;

    public float speed = 200;

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
        Loop();
    }
    public void Init()
    {
        InitPlaying();
    }
    void Loop()
    {
        if(state == states.PLAYING)
            speed++;
        Invoke("Loop", 1);
    }
    void InitPlaying()
    {
        state = states.PLAYING;
    }
    public void Fire()
    {
        nave.Fire();
    }
    public void OnGameOver()
    {
        obstacles.Reset();
        state = states.GAME_OVER;
    }
}
