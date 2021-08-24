using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideogameObstacle : MonoBehaviour
{
    float speed;
    public float max = 550;
    VideogameObstacles obstacles;

    public void Init(VideogameObstacles obstacles, float speed)
    {
        this.obstacles = obstacles;
        this.speed = speed;
    }

    void Update()
    {
        Vector2 pos = transform.localPosition;
        pos.y -= speed * Time.deltaTime;
        transform.localPosition = pos;
        if (transform.localPosition.y < -max)
            End();
    }
    void End()
    {
        obstacles.Delete(this);
        Destroy(gameObject);
    }
    public void OnFired()
    {
        End();
    }
    public void OnHitNave()
    {
        End();
    }
}
