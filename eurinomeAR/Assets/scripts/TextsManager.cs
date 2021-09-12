using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TextsManager : MonoBehaviour
{
    public TextAsset textAsset;
    public AllData all;

    private void Awake()
    {
        all = JsonUtility.FromJson<AllData>(textAsset.text);
    }
    [Serializable]
    public class AllData
    {
        public TextData[] all;
    }
    [Serializable]
    public class TextData
    {
        public string id;
        public string text;
    }
    public string GetText(string id)
    {
        foreach (TextData td in all.all)
            if (id == td.id)
                return td.text;
        Debug.LogError("No hay texto para " + id);
        return "";
    }
}
