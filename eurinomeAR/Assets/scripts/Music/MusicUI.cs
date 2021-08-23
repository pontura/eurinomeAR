using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicUI : MonoBehaviour
{
    public NotesManager[] notesManager;
    public ARButton[] buttons;
    Animation anim;

    public int id = 1; 

    void Start()
    {
        anim = GetComponent<Animation>();
        SetButtons();

    }
    void OnToogle()
    {
        if (id == 1)
            id = 2;
        else
            id = 1;
        SetButtons();
        if (id == 1)
            anim.Play("toggle1");
        else
            anim.Play("toggle2");
    }
    public void OnPointerDown()
    {
        foreach (NotesManager nm in notesManager)
            nm.isOn = false;
    }
    public void OnPointerUp()
    {
        foreach (NotesManager nm in notesManager)
            nm.isOn = true;

        OnToogle();
    }
    void SetButtons()
    {

        foreach (NotesManager nm in notesManager)
            nm.isOn = false;

        notesManager[id - 1].isOn = true;

        int buttonID = 0;
        foreach (ARButton arButton in buttons)
        {
            arButton.Init(buttonID, OnClicked);
            buttonID++;
        }
    }
    void OnClicked(int id)
    {
        OnToogle();
    }
}
