using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class PartUIButton : MonoBehaviour
{
    public DressUI.PartData partData;
    System.Action<int> Clicked;
    public int id;
    public GameObject isOn;
    public Image image;

    public virtual void Init(int id, System.Action<int> Clicked, DressUI.PartData partData)
    {
        this.id = id;
        this.Clicked = Clicked;
        this.partData = partData;
        if(partData != null)
            image.sprite = partData.sprite;
    }
    public void OnClicked()
    {
        Clicked(id);
    }
    public void SetOn(bool _isOn)
    {
        isOn.SetActive(_isOn);
    }
}
