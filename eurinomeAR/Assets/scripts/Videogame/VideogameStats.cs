using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class VideogameStats : MonoBehaviour
{
    public GameObject[] fields;
    public int active;
    public StatData[] all;
    public Videogame videogame;
    public GameObject levelSignal;
    public Text levelSignalField;
    public float multiplier = 20;
    public Text speedYFField;

    [Serializable]
    public class StatData
    {
        public int level;
        public float speed;
        public float density;
        public float qty_shots;
        public float shoots_in_screen;
    }

    void Start()
    {
        SetStat(0);
    }
    public void SetStat(int active)
    {
        levelSignal.SetActive(true);
        SetSpeed(0);
        this.active = active;
        SetFields(fields[0], "NIVEL", all[active].level.ToString());
        SetFields(fields[2], "DENSIDAD", all[active].density.ToString());
        SetFields(fields[3], "RESISTENCIA", all[active].qty_shots.ToString());
        SetFields(fields[4], "DISPAROS", all[active].shoots_in_screen.ToString());

        videogame.obstacles.ChangeStats();
        levelSignalField.text = "NIVEL "+ all[active].level.ToString();
        levelSignal.GetComponent<Animation>().Play();
    }
    public int newSpeed;
    public void SetSpeed(float acceleration)
    {
        newSpeed = (int)(all[active].speed + (acceleration * multiplier));
        videogame.obstacles.SetSpeed(newSpeed);
        SetFields(fields[1], "VELOCIDAD", newSpeed.ToString());
        speedYFField.text = newSpeed.ToString();
    }
    void SetFields(GameObject go, string text1, string text2)
    {
        Text[] arr = go.GetComponentsInChildren<Text>();
        arr[0].text = text1;
        arr[1].text = text2;
    }
    public StatData Get()
    {
        return all[active];
    }
}
