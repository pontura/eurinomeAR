using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideogameFire : MonoBehaviour
{
    float speed;
    public float max = 550;
    VideogameNave nave;

    public void Init(VideogameNave nave, float speed)
    {
        this.nave = nave;
        this.speed = speed;
    }

    void Update()
    {
        Vector2 pos = transform.localPosition;
        pos.y += speed * Time.deltaTime;
        transform.localPosition = pos;
        if (transform.localPosition.y > max)
            End();
    }
    void End()
    {
        nave.ResetShoot();
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        VideogameObstacle obstacle = collision.gameObject.GetComponent<VideogameObstacle>();
        if (obstacle != null)
        {
            obstacle.OnFired();
            End();
        }
    }
}
