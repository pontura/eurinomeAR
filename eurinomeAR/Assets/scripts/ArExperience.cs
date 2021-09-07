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
    public GameObject intro;
    public GameObject game;
    public ARButton closeButton;
    public ARButton playButton;
    bool playClicked;

    public void Init()
    {        
        GotoIntro();
        closeButton.Init(0, OnClose);
        playButton.Init(1, OnButtonclicked);
    }
    void OnClose(int id)
    {
        GotoIntro();
    }
    public void SetOn(bool isOn)
    {
        gameObject.SetActive(isOn);
    }
    public void GotoGame()
    {
        closeButton.gameObject.SetActive(true);
        state = states.GAME;
        intro.SetActive(false);
        game.SetActive(true);
    }
    public void GotoIntro()
    {
        playClicked = false;
        closeButton.gameObject.SetActive(false);
        state = states.INTRO;
        intro.SetActive(true);
        game.SetActive(false);
    }
    void OnButtonclicked(int id)
    {
        if (playClicked) return;
        playClicked = true;
        Invoke("DoAction", 0.5f);
        playClicked = true;
    }
    void DoAction()
    {
        playClicked = false;
        GetComponentInParent<ArExperience>().GotoGame();
    }
}
