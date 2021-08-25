using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PngSequenceAnim : MonoBehaviour
{
    public Sprite[] all;
    public Image image;
    System.Action OnDone;
    int id = 0;
    float speed = 0.2f;

    public void Init(System.Action OnDone, float speed = 0.2f)
    {
        this.speed = speed;
        gameObject.SetActive(true);
        id = 0;
        this.OnDone = OnDone;
        Loop();
    }
    void Loop()
    {
        if (id >= all.Length)
        {
            gameObject.SetActive(false);
            OnDone();
        }
        else
        {
            Sprite s = all[id];
            image.sprite = s;
            id++;
            Invoke("Loop", speed);
        }
    }
}
