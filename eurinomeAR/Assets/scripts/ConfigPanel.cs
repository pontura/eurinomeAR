using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigPanel : MonoBehaviour
{
    public GameObject panel;
    bool isOpen;
    public ArExperience[] games;
    public InputField[] scaleInputfields;
    public InputField[] durationsInputfields;
    public List<int> durations;
    public GameObject scalesContainer;
    public GameObject durationContainer;
    public bool forceInitActive;
    public GameObject qrPanelFilm;

    private void Awake()
    {
        qrPanelFilm.SetActive(false);
    }
    void Start()
    {
        PlayerPrefs.DeleteAll();
        Close();
        int id = 0;
        scaleInputfields = scalesContainer.GetComponentsInChildren<InputField>();
        foreach (InputField f in scaleInputfields)
        {
            string t = PlayerPrefs.GetString("scale_" + id, "50");
            f.text = t;
            id++;
        }
        id = 0;
        durationsInputfields = durationContainer.GetComponentsInChildren<InputField>();
        foreach (InputField f in durationsInputfields)
        {
            f.text = PlayerPrefs.GetString("duration_" + id, f.text);
            id++;
            durations.Add(int.Parse(f.text));
        }
        if (forceInitActive)
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
        qrPanelFilm.SetActive(true);
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
        qrPanelFilm.SetActive(false);
        int thisID = 0;
        print("OnTargetFound " + id);
        foreach (ArExperience arExperience in games)
        {
            if (thisID == id-1)
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
        int id = 0;
        foreach (ArExperience arExperience in games)
        {
            float scale = float.Parse(scaleInputfields[id].text);
            PlayerPrefs.SetString("scale_" + id, scale.ToString());
            arExperience.transform.localScale = new Vector3(scale/100, scale/100, scale / 100);
            id++;
        }
    }
    public void SaveDurations()
    {
        durations.Clear();
        int id = 0;
        foreach (InputField f in durationsInputfields)
        {
            PlayerPrefs.SetString("duration_" + id, f.text.ToString());
            durations.Add(int.Parse(f.text));
            id++;
        }
    }
}
