using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PistasManager : MonoBehaviour
{
    public int id = 0;
    public int duration;
    public GameObject panel;
    public Text field;
    public Animation anim;
    public float timer;
    public float nextTimer;
    public bool isOver;
    public InputField initialTimeInputfield;
    public Text countDownField;
    int totalDuration = 705;

    private void Start()
    {
        isOver = true;
        countDownField.text = "";
        Invoke("Init", 3);
        Invoke("Delayed", 0.1f);
    }
    int cid = 3;
    void Delayed()
    {
        totalDuration = GetComponent<ConfigPanel>().totalDuration;
        if (cid == 3)
            Events.PlaySound("bg", "countdown", false);
        if (cid > 0)
        {
            countDownField.text = cid.ToString();
            cid--;
            Invoke("Delayed", 1);
        }
        else
            countDownField.text = "";
    }
    public void Reset()
    {
        animName = "reset";
        anim.Play(animName);
        field.text = "";
        isOver = true;
        panel.SetActive(true);
      //  buttonInit.SetActive(true);
        ResetVuforia();
    }
    //public 
    void Init() 
    {
        animName = "reset";
        anim.Play(animName);
        // buttonInit.SetActive(false);
        nextTimer = int.Parse(initialTimeInputfield.text);
        GamesManager.Instance.SetVuforiaOn(false);
        anim.Play("fullScreen");


        field.text = "";
        timer = 0;
        id = 0;
        isOver = false;

        Show();
    }
    string animName = "";
    void Update()
    {
        timer += Time.deltaTime;

        if (isOver)
            return;

        if (timer > nextTimer-1 && animName != "text_off")
        {
            animName = "text_off";
            anim.Play(animName);
        }
        if (timer > nextTimer)
            Next();
        if (timer > totalDuration) //705 es 6:45
        {
            GetComponent<ConfigPanel>().Quit();
        }
    }
    void Next()
    {
        id++;
        Show();
    }
    void Show()
    {
        switch(id)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                PlayPista(id);
                break;
            case 6:                
                PlayPista(id);
                OpenRA();
                break;
            case 7:
            case 8:
            case 9:
                field.text = "";
                //PlayPista(id);
                break;
            case 10:
                PlayPista(id);
                anim.Play("bak");
                Invoke("ResetVuforia", 3);
                GamesManager.Instance.CloseAllApps();
                break;
            case 11:
                field.text = "";
                anim.Play("gameover");
                return;
        }
        if (id >= GamesManager.Instance.configs.durations.Count)
            nextTimer += 25;
        else
            nextTimer = GamesManager.Instance.configs.durations[id];
    }
    void ResetVuforia()
    {
        GamesManager.Instance.SetVuforiaOn(false);
    }
    void PlayPista(int id)
    {
        animName = "text_on";
        anim.Play(animName);
        field.text = GamesManager.Instance.texts.GetText("pista_" + id);
    }
    public void OpenRA()
    {
        GamesManager.Instance.SetVuforiaOn(true);
        anim.Play("ar");
        field.text = "";
      //  buttonInit.SetActive(false);
    }
}
