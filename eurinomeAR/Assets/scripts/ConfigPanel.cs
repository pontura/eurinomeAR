using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigPanel : MonoBehaviour
{
    public GameObject panel;
    bool isOpen;
    public ArExperience[] games;
    public InputField scaleField;
    float scale = 100;
    public bool forceInitActive;

    void Start()
    {
        Close();
        scaleField.text = scale.ToString();
        if(forceInitActive)
        {
            foreach (ArExperience a in games)
                if (a.isActiveAndEnabled)
                    a.Init();
        }
    }
    public void Toggle()
    {        
        if (isOpen)
            Close();
        else
            Open();
    }
    void Open()
    {
        isOpen = true;
        panel.SetActive(true);
    }
    void Close()
    {
        isOpen = false;
        panel.SetActive(false);
    }
    public void OnTargetHide(int id)
    {
        print("____OnTargetHide__ " + id);
        int thisID = 0;
        foreach (ArExperience arExperience in games)
        {
            if (thisID == id)
                arExperience.SetOn(false);
            thisID++;
        }
    }
    int lastIdFound = -1;
    public void OnTargetFound(int id)
    {
        int thisID = 0;
        foreach (ArExperience arExperience in games)
        {
            if (thisID == id)
            {
                arExperience.SetOn(true);
                if (id != lastIdFound)
                    arExperience.Init();
            }
            else
                arExperience.SetOn(false);
            thisID++;
        }        
        lastIdFound = id;
    }
    public void SetScale()
    {
        float scale = float.Parse(scaleField.text);
        foreach (ArExperience arExperience in games)
        {
            arExperience.transform.localScale = new Vector3(scale/100, scale/100, scale / 100);
        }
    }
}
