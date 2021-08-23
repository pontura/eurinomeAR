using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DressupUI : MonoBehaviour
{
    public int id;
    public ARButton[] buttons;
    public Transform partButtonsContainer;
    public Transform colorButtonsContainer;
    public PartData[] hatsData;

    public PartARButton partButton;
    public ColorARButton colorButton;

    [HideInInspector]public List<PartARButton> partButtons;
    [HideInInspector] public List<ColorARButton> colorButtons;

    SpriteRenderer activeSprite;

    [Serializable]
    public class PartData
    {
        public Sprite sprite;
        public SpriteRenderer sr;
        public string paletaName;
    }
    [Serializable]
    public class PaletasData
    {
        public string paletaName;
        public Color[] colors;
    }
    public PaletasData[] paletas;

    void Start()
    {
        int buttonID = 0;
        foreach (ARButton arButton in buttons)
        {
            arButton.Init(buttonID, OnClicked);
            buttonID++;
        }        
    }
    public void OnClicked(int id)
    {
        this.id = id;
        foreach (ARButton arButton in buttons)
        {
            if (arButton.id == id)
                arButton.SetOn(true);
            else
                arButton.SetOn(false);
        }
        SetPartsButton(hatsData);
    }



    //PARTS:
    void SetPartsButton(PartData[] parts)
    {
        Utils.RemoveAllChildsIn(partButtonsContainer);
        partButtons.Clear();
        int buttonID = 0;
        float offset = 1.5f;
        foreach (PartData data in parts)
        {
            PartARButton pButton = Instantiate(partButton, partButtonsContainer);
            pButton.Init(buttonID, OnPartClicked);
            pButton.partData = data;
            pButton.transform.localPosition = new Vector3(0, buttonID*offset, 0);
            buttonID++;
            partButtons.Add(pButton);
        }
        OnPartClicked(0);
    }
    public void OnPartClicked(int id)
    {
        this.id = id;
        foreach (ARButton partButton in partButtons)
        {
            if (partButton.id == id)
                partButton.SetOn(true);
            else
                partButton.SetOn(false);
        }
        PartData pData = partButtons[id].partData;
        pData.sr.sprite = pData.sprite;
        activeSprite = pData.sr;
        activeSprite.color = Color.white;
        SetColorButton(GetColorsFromPaleta(pData.paletaName));
    }

    Color[] GetColorsFromPaleta(string paletaName)
    {
        foreach(PaletasData pData in paletas)
        {
            if (pData.paletaName == paletaName)
                return pData.colors;
        }
        Debug.LogError("No hay paleta para " + paletaName);
        return null;
    }


    //COLORS:
    void SetColorButton(Color[] colors)
    {
        Utils.RemoveAllChildsIn(colorButtonsContainer);
        colorButtons.Clear();
        int buttonID = 0;
        float offset = 1.5f;
        foreach (Color data in colors)
        {
            ColorARButton pButton = Instantiate(colorButton, colorButtonsContainer);
            pButton.Init(buttonID, OnColorClicked);
            pButton.SetColor(data);
            pButton.transform.localPosition = new Vector3(0, buttonID * offset, 0);
            buttonID++;
            colorButtons.Add(pButton);
        }
    }
    public void OnColorClicked(int id)
    {
        print("OnColorClicked");
        this.id = id;
        foreach (ColorARButton cButton in colorButtons)
        {
            if (cButton.id == id)
                cButton.SetOn(true);
            else
                cButton.SetOn(false);
        }
        Color color = colorButtons[id].color;
        activeSprite.color = color;
    }
}
