using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArExperience : MonoBehaviour
{
    public states state;
    public enum states
    {
        INTRO,
        GAME
    }
    public Intro intro;
    public GameObject game;

    public void Init()
    {
        state = states.INTRO;
        intro.gameObject.SetActive(true);
        game.gameObject.SetActive(false);
    }
    public void SetOn(bool isOn)
    {
        gameObject.SetActive(isOn);
    }
    public void GotoGame()
    {
        state = states.GAME;
        intro.gameObject.SetActive(false);
        game.gameObject.SetActive(true);

    }
}
