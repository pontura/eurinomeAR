using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideogameNave : MonoBehaviour
{
    public Videogame videogame;
    public float x_offset = 600;
    public VideogameFire fire;
    public float fireSpeed = 1000;
    public PngSequenceAnim explotion;
    public GameObject asset;

    bool canFire = true;

    private void Start()
    {
        asset.SetActive(true);
        explotion.gameObject.SetActive(false);
    }

    public void Fire()
    {
        if (!canFire) return;
        VideogameFire f = Instantiate(fire, transform.parent);
        f.Init(this, fireSpeed);
        Vector2 pos = transform.localPosition;
        pos.y += 50;
        f.transform.localPosition = pos;
        canFire = false;
    }
    private void Update()
    {
        if(videogame.state == Videogame.states.PLAYING)
        {
            float _x = (Input.mousePosition.x - (Screen.width/2) ) / (Screen.width/2);
            Vector2 pos = transform.localPosition;
            float to = _x * x_offset;
            pos.x = Mathf.Lerp(pos.x, to, 0.2f);
            transform.localPosition = pos;
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }
        }
        
    }
    public void ResetShoot()
    {
        canFire = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        VideogameObstacle obstacle = collision.gameObject.GetComponent<VideogameObstacle>();
        if (obstacle != null)
        {
            obstacle.OnFired();
            asset.gameObject.SetActive(false);
            explotion.Init(OnDone);
            videogame.OnGameOver();
        }
    }
    void OnDone()
    {
        asset.gameObject.SetActive(true);
        videogame.Init();
    }

}
