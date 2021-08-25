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

    void Start()
    {
        Close();
        scaleField.text = scale.ToString();
    }
    public void Toggle()
    {        
        if (isOpen)
            Close();
        else
            Open();
        isOpen = !isOpen;
    }
    void Open()
    {
        panel.SetActive(true);
    }
    void Close()
    {
        isOpen = false;
        panel.SetActive(false);
    }
    public void ShowGame(int id)
    {
        int thisID = 0;
        foreach (ArExperience arExperience in games)
        {
            if (thisID == id)
                arExperience.SetOn(true);
            else
                arExperience.SetOn(false);
            thisID++;
        }
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
