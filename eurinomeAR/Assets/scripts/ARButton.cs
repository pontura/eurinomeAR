using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARButton : MonoBehaviour
{
    System.Action<int> OnClicked;
    public int id;
    Animation anim;

    public void Init(int id, System.Action<int> OnClicked)
    {
        this.OnClicked = OnClicked;
        this.id = id;
        anim = GetComponent<Animation>();
    }
    public void OnButtonClick()
    {
        if (OnClicked == null)
        {
            Debug.LogError("No hace nada este boton");
            return; 
        }
        this.OnClicked(id);
        SetOn(true);
    }
    public void SetOn(bool isOn)
    {
        if (anim == null) return;
        if(isOn)
            anim.Play("buttonOn");
        else
            anim.Play("buttonOff");
    }
}
