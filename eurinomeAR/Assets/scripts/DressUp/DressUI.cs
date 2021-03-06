using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DressUI : GameMain
{
    public int id;
    public Animation character;
    public PartUIButton[] buttons;
    public Transform partButtonsContainer;
    public Transform colorButtonsContainer;

    public PartData[] hatsData;
    public PartData[] remerasData;
    public PartData[] pantalonesData;
    public PartData[] zapatillasData;

    public PartUIButton partButton;
    public ColorUIButton colorButton;

    public List<PartUIButton> partButtons;
    public List<ColorUIButton> colorButtons;
    public List<PartUIButton> patternsButtons;

    public Transform hatContainer;
    public Transform remeraContainer;
    public Transform pantalonContainer;
    public Transform zapatillaContainer;

    [Serializable]
    public class PartData
    {
        public Sprite sprite;
        public GameObject prefab;
        public string paletaName;
    }
    [Serializable]
    public class PaletasData
    {
        public string paletaName;
        public Color[] colors;
    }
    public PaletasData[] paletas;

    public override void Reset()
    {
        base.Reset();
    }
    private void OnEnable()
    {
        OnMenuClicked(0);
        Invoke("Delayed", 0.7f);
    }
    void Delayed()
    {
        Events.OnTip(TipController.types.INITIAL_TIP, GamesManager.Instance.texts.GetText("INITIAL_TIP_DRESS"), true);
    }
    Transform container;
    public void OnMenuClicked(int id)
    {
        Events.OnTip(TipController.types.INITIAL_TIP, "", false);
        this.id = id;
        foreach (PartUIButton arButton in buttons)
        {
            if (arButton.id == id)
                arButton.SetOn(true);
            else
                arButton.SetOn(false);
        }
        switch(id)
        {
            case 0:
                SetPartsButton(hatsData);
                break;
            case 1:
                SetPartsButton(remerasData);
                break;
            case 2:
                SetPartsButton(pantalonesData);
                break;
            case 3:
                SetPartsButton(zapatillasData);
                break;
        }
    }
    void SetPartsButton(PartData[] parts)
    {
        Utils.RemoveAllChildsIn(partButtonsContainer);
        partButtons.Clear();
        int buttonID = 0;
        foreach (PartData data in parts)
        {
            PartUIButton pButton = Instantiate(partButton, partButtonsContainer);
            pButton.Init(buttonID, OnPartClicked, data);
            pButton.partData = data;
            buttonID++;
            partButtons.Add(pButton);
        }
        OnPartClicked(0);
    }
    public void OnPartClicked(int id)
    {
        Events.OnTip(TipController.types.INITIAL_TIP, "", false);
        OnChange();
        foreach (PartUIButton partButton in partButtons)
        {
            if (partButton.id == id)
                partButton.SetOn(true);
            else
                partButton.SetOn(false);
        }
        PartData pData = partButtons[id].partData;
        container = Getcontainer(partButtons[id].partData.paletaName);
        Utils.RemoveAllChildsIn(container);
        GameObject prefab = Instantiate(pData.prefab, container);
        prefab.transform.localScale = Vector3.one;
        prefab.transform.localPosition = Vector3.zero;
        OnPattern(patternId);
        OnColor(colorId);
    }
    Transform Getcontainer(string name)
    {
        switch(name)
        {
            case "hats": return hatContainer;
            case "zapas": return zapatillaContainer;
            case "remera": return remeraContainer;
            default: return pantalonContainer;
        }
    }
    Color[] GetColorsFromPaleta(string paletaName)
    {
        foreach (PaletasData pData in paletas)
        {
            if (pData.paletaName == paletaName)
                return pData.colors;
        }
        Debug.LogError("No hay paleta para " + paletaName);
        return null;
    }

    int patternId;
    public void OnPatternClicked(int id)
    {
        this.patternId = id;
        OnChange();
        OnPattern(id);
    }
    void OnPattern(int id)
    {
        PartUIButton p = null;
        foreach (PartUIButton cButton in patternsButtons)
        {
            if (cButton.id == id)
            {
                cButton.SetOn(true);
                p = cButton;
            }
            else
                cButton.SetOn(false);
        }
        Image[] all = container.GetComponentsInChildren<Image>();
        print(all.Length);
        print(p);
        all[2].sprite = p.partData.sprite;
    }

    ////COLORS:
    //void SetColorButton(Color[] colors)
    //{
    //    Utils.RemoveAllChildsIn(colorButtonsContainer);
    //    colorButtons.Clear();
    //    int buttonID = 0;
    //    float offset = 1.5f;
    //    foreach (Color data in colors)
    //    {
    //        ColorUIButton pButton = Instantiate(colorButton, colorButtonsContainer);
    //        pButton.Init(buttonID, OnColorClicked);
    //        pButton.SetColor(data);
    //        pButton.transform.localPosition = new Vector3(0, buttonID * offset, 0);
    //        buttonID++;
    //        colorButtons.Add(pButton);
    //        pButton.SetOn(false);
    //    }
    //}
    int colorId;
    public void OnColorClicked(int id)
    {
        this.colorId = id;
        OnChange();
        OnColor(id);
    }
    public void OnColor(int id)
    {
        this.colorId = id;
        OnChange();
        foreach (ColorUIButton cButton in colorButtons)
        {
            if (cButton.id == id)
                cButton.SetOn(true);
            else
                cButton.SetOn(false);
        }
        Color color = colorButtons[id].color;
        container.GetComponentInChildren<Image>().color = color;
    }
    private void OnChange()
    {
        Events.PlaySound("ui", "select", false);
        character.Play();
    }
}
