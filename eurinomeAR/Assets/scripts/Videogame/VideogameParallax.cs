using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideogameParallax : MonoBehaviour
{
    public GameObject bg1;
    public Videogame videogame;
    public int dividedBy = 2;

    void Update()
    {
        Vector2 pos = bg1.transform.localPosition;
        pos.y -= (videogame.stats.newSpeed / dividedBy) * Time.deltaTime;

        if (pos.y < -900)
            pos.y = 0;

        bg1.transform.localPosition = pos;
        
    }
}
