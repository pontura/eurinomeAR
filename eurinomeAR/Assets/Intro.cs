using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public ARButton next;
    bool clicked;
    int id;

    void Start()
    {
        next.Init(0, OnButtonclicked);
    }
    void OnButtonclicked(int id)
    {
        if (clicked) return;
        this.id = id;
        clicked = true;
        Invoke("DoAction", 0.5f);
        clicked = true;
    }
    void DoAction()
    {
        clicked = false;
        switch(id)
        {
            case 0:
                GetComponentInParent<ArExperience>().GotoGame();
                break;
        }
    }
}
