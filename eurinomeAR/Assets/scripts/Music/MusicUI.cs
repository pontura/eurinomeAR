using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicUI : MonoBehaviour
{
    public GameObject[] presets;
    public Transform container;
    NotesManager[] notesManager;
    Animation anim;
    public MusicTrail[] trails;

    public int id = 1; 

    void Start()
    {
        anim = GetComponent<Animation>();
        OnPresetClicked(0);
        SetButtons();
    }
    public void OnToogle()
    {
        if (id == 1)
            id = 2;
        else
            id = 1;
        SetButtons();
        if (id == 1)
        {
            Events.OnTipTimout(TipController.types.MUSIC_1, GamesManager.Instance.texts.GetText("MUSIC_1"), 2);
            anim.Play("toggle1");
        }
        else
        {
            Events.OnTipTimout(TipController.types.MUSIC_2, GamesManager.Instance.texts.GetText("MUSIC_2"), 2);
            anim.Play("toggle2");
        }
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
    }
    void OnClicked(int id)
    {
        OnToogle();
    }
    public void OnPresetClicked(int id)
    {
        Utils.RemoveAllChildsIn(container);
        GameObject go = Instantiate(presets[id], container);
        go.transform.localPosition = Vector3.zero;
        notesManager = go.GetComponentsInChildren<NotesManager>();
        int _id = 0;
        foreach(NotesManager ns in notesManager)
        {
            ns.musicTrail = trails[_id];
            _id++;
        }
    }
}
