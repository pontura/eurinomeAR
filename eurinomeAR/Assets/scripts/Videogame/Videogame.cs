using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Videogame : MonoBehaviour
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
    public void Init()
    {
        InitPlaying();
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
