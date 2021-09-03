using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideogameUI : MonoBehaviour
{
    public ARButton[] buttons;
    public Videogame videogame;
    public Text scoreField;
    public VideogameStats stats;
    int score = 0;

    void Start()
    {
        if (buttons.Length == 0)
            return;
        score = 0;
        int id = 0;
        foreach(ARButton b in buttons)
        {
            b.Init(id, OnClick);
            id++;
        }
        buttons[0].OnButtonClick();
    }

    void OnClick(int id)
    {
        foreach (ARButton b in buttons)
        {
            if (b.id == id)
                b.SetOn(true);
            else
                b.SetOn(false);
        }
        stats.SetStat(id);
    }
    public void AddScore(int qty)
    {
        score += qty;
        scoreField.text = score.ToString();
    }
}
