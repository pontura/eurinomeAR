using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DressUI : MonoBehaviour
{
    public int id;
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

    
    public void OnMenuClicked(int id)
    {
        this.id = id;
        foreach (PartUIButton arButton in buttons)
        {
            if (arButton.id == id)
                arButton.SetOn(true);
            else
                arButton.SetOn(false);
        }
        SetPartsButton(remerasData);
    }



    //PARTS:
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
        foreach (PartUIButton partButton in partButtons)
        {
            if (partButton.id == id)
                partButton.SetOn(true);
            else
                partButton.SetOn(false);
        }
        PartData pData = partButtons[id].partData;
        Utils.RemoveAllChildsIn(remeraContainer);
        GameObject prefab = Instantiate( pData.prefab, remeraContainer);
        //prefab.transform.localPosition = Vector3.zero;
        prefab.transform.localScale = Vector3.one;

        //SetColorButton(GetColorsFromPaleta(pData.paletaName));
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


    public void OnPatternClicked(int id)
    {
        print("OnPatternClicked");
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
        Image[] all = remeraContainer.GetComponentsInChildren<Image>();
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
    public void OnColorClicked(int id)
    {
        print("OnColorClicked");
        foreach (ColorUIButton cButton in colorButtons)
        {
            if (cButton.id == id)
                cButton.SetOn(true);
            else
                cButton.SetOn(false);
        }
        Color color = colorButtons[id].color;
        remeraContainer.GetComponentInChildren<Image>().color = color;
    }
}
