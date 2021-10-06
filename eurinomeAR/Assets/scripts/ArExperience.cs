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
   // public ARButton closeButton;
    public ARButton playButton;
    public bool playClicked;
    public GameMain gameMain;

    void OnEnable()
    {
        Init();
        print("empty");
    }
    void OnDisable()
    {
        Animation anim = intro.GetComponent<Animation>();
        anim.Play("empty");
    }
    public void Init()
    {
        print("SI playClicked: " + playClicked);
        if (!playClicked)
        {
            Animation anim = intro.GetComponent<Animation>();
            anim.Play("empty");
            GotoIntro();
        }
        else
            GotoGame();
        playButton.Init(1, OnButtonclicked);
    }
    public void SetOn(bool isOn)
    {
        print("setOn" + isOn + " go name: " + this.gameObject.name);
        gameObject.SetActive(isOn);
    }
    public void GotoGame()
    {
        Events.PlaySpecificSound(null);
        // closeButton.gameObject.SetActive(true);
        state = states.GAME;
        intro.SetActive(false);
        if (!playClicked)
        {
            Animation anim = game.GetComponent<Animation>();
            if (anim != null)
                anim.Play();
        }
        game.SetActive(true);
    }
    
    public void GotoIntro()
    {
        Animation anim = intro.GetComponent<Animation>();
        anim.Play("intro");
        playClicked = false;
        // closeButton.gameObject.SetActive(false);
        state = states.INTRO;
        intro.SetActive(true);
        game.SetActive(false);
    }
    void OnButtonclicked(int id)
    {
        if (playClicked) return;
        playClicked = true;
        Invoke("DoAction", 0.5f);
    }
    void DoAction()
    {
        GetComponentInParent<ArExperience>().GotoGame();
    }
    public void Reset()
    {
        playClicked = false;
        gameMain.Reset();
    }
}
