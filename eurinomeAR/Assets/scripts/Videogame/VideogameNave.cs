using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideogameNave : MonoBehaviour
{
    public Videogame videogame;
    public float x_offset = 600;
    public VideogameFire fire;
    public float fireSpeed = 1000;
    public float speed = 100;
    public PngSequenceAnim explotion;
    public GameObject asset;
    public Transform targetToMove;
    int totalShots;

    public void Init()
    {
        asset.SetActive(true);
        explotion.gameObject.SetActive(false);
    }
    public void Fire()
    {
        float shoots_in_screen = videogame.stats.Get().shoots_in_screen;
        if (totalShots >= shoots_in_screen) return;

        totalShots++;
        print("totalShots: " + totalShots + " shoots_in_screen: " + shoots_in_screen);

        VideogameFire f = Instantiate(fire, transform.parent);
        f.Init(this, fireSpeed);
        Vector2 pos = transform.localPosition;
        pos.y += 50;
        f.transform.localPosition = pos;
        Events.PlaySound("common", "naveGun", false);
    }
    private void Update()
    {
        if(videogame.state == Videogame.states.PLAYING)
        {
            Vector2 pos = transform.localPosition;
            pos.x += GamesManager.Instance.analogicKnob.NormalizedAxis.x * speed * Time.deltaTime;
            if (pos.x < -x_offset) pos.x = -x_offset;
            if (pos.x > x_offset) pos.x = x_offset;
            transform.localPosition = pos;
        }
        
    }
    public void ResetShoot()
    {
        totalShots--;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        VideogameObstacle obstacle = collision.gameObject.GetComponentInParent<VideogameObstacle>();
        if (obstacle != null)
        {
            obstacle.OnFired();
            asset.gameObject.SetActive(false);
            explotion.Init(OnDone);
            videogame.OnGameOver();
            Events.PlaySound("common", "explosion", false);
        }
    }
    public void OnDone()
    {
        videogame.Restart();
    }

}
