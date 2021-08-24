using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideogameObstacles : MonoBehaviour
{
    public float max = 550;
    public List<VideogameObstacle> obstacles;
    Videogame videogame;
    public VideogameObstacle[] to_instantiate;
    public Transform container;

    public void Init(Videogame videogame)
    {
        this.videogame = videogame;
        Loop();
    }
    void Loop()
    {
        Invoke("Loop", 1);
        Add();
    }
    void Add()
    {
        VideogameObstacle o = to_instantiate[Random.Range(0, to_instantiate.Length)];
        VideogameObstacle newObstacle = Instantiate(o, container);
        newObstacle.transform.localPosition = new Vector2(Random.Range(-500, 500), 550);
        newObstacle.Init(this, videogame.speed);
        obstacles.Add(newObstacle);
    }
    public void Delete(VideogameObstacle obstacle)
    {
        obstacles.Remove(obstacle);
        videogame.ui.AddScore(15);
    }
    public void Reset()
    {
        print("RESET");
        int i = obstacles.Count;
        while(i>0)
        {
            VideogameObstacle o = obstacles[i-1];
            o.OnFired();
            i--;
        }
    }
}
