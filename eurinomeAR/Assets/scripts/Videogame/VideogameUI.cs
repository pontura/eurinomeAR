using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideogameUI : MonoBehaviour
{
    public ARButton button;
    public Videogame videogame;
    public Text scoreField;
    int score = 0;

    void Start()
    {
        button.Init(0, OnClick);
        score = 0;
    }

    void OnClick(int id)
    {
        
    }
    public void AddScore(int qty)
    {
        score += qty;
        scoreField.text = score.ToString();
    }
}
