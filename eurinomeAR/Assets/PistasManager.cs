using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PistasManager : MonoBehaviour
{
    public int id = 1;
    public int duration;
    public GameObject panel;
    public Text field;
    public Animation anim;

    private void Start()
    {
        panel.SetActive(true);
        Invoke("Init", 1);
    }
    public void Init()
    {
        GamesManager.Instance.SetVuforiaOn(false);
        anim.Play("fullScreen");
        Show();
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
                PlayPista(id);
                break;
            case 4:
                GamesManager.Instance.SetVuforiaOn(true);
                anim.Play("ar");
                PlayTip(1);
                break;
            case 5:
                PlayTip(2);
                break;
            case 6:
                PlayTip(3);
                break;
            case 7:
                PlayTip(4);
                break;
            case 8:
                anim.Play("bak"); PlayPista(id - 4);
                Invoke("ResetVuforia", 3);
                break;
            case 9:
            case 10:
            case 11:
                PlayPista(id - 4);
                break;
            case 12:
                print("final");
                return;
        }
        duration = GamesManager.Instance.configs.durations[id-1];
        Invoke("Next", duration);
    }
    void ResetVuforia()
    {
        GamesManager.Instance.SetVuforiaOn(false);
    }
    void PlayPista(int id)
    {
        Events.PlaySound("ui", "pista" + id, false);
        field.text = GamesManager.Instance.texts.GetText("pista_" + id);
    }
    void PlayTip(int id)
    {
        Events.PlaySound("ui", "tip" + id, false);
        field.text = "";// GamesManager.Instance.texts.GetText("tip" + id);
    }
}
