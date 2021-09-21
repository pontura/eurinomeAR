using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideogameUI : MonoBehaviour
{
    public Toggle[] buttons;
    public Videogame videogame;
    public Text scoreField;
    public VideogameStats stats;
    int score = 0;
    public Text speedXField;
    public Slider speedY;
    public Slider speedX;

    void Start()
    {
        if (buttons.Length == 0)
            return;
        score = 0;
        int id = 0;
        OnClick(0);
    }
    public void OnClick(int id)
    {
        if (!buttons[id].isOn) return;

        speedY.value = 0;
        stats.SetStat(id);
        OnRefreshSpeed();
        int _id = 0;
        foreach (Toggle b in buttons)
        {
            if (_id == id)
                b.isOn = true;
            else
                b.isOn = false;
            _id++;
        }
    }
    public void OnRefreshSpeed()
    {
        stats.SetSpeed(speedY.value);
    }
    public void OnRefreshSpeedX()
    {
        videogame.nave.SetSpeed(speedX.value);
        speedXField.text = (speedX.value * 1000) + " km/h";
    }
    public void AddScore(int qty)
    {
        score += qty;
        scoreField.text = score.ToString();
    }
}
