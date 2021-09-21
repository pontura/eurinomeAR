using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideogameObstacle : MonoBehaviour
{
    float speed;
    public float max = 550;
    VideogameObstacles obstacles;
    public GameObject asset;
    public PngSequenceAnim explotion;
    public GameObject[] assets;

    public void Init(VideogameObstacles obstacles)
    {
        this.obstacles = obstacles;
        explotion.gameObject.SetActive(false);
        RefreshStats();

        if (Random.Range(0, 10) < 5)
            transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
    }
    public void RefreshStats()
    {
        VideogameStats.StatData data = obstacles.videogame.stats.Get();
        SetSpeed(data.speed);
        foreach (GameObject go in assets)
            go.SetActive(false);
        assets[data.level - 1].SetActive(true);
        Animation anim = GetComponentInChildren<Animation>();
        if(anim != null)  GetComponentInChildren<Animation>().Play("obstacle" + data.level);
    }
    public void SetSpeed(float _speed)
    {
        speed = _speed;
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
        DestroyAsset();
    }
    public void OnHitNave()
    {
        DestroyAsset();
    }
    void DestroyAsset()
    {
        Events.PlaySound("common", "explosion", false);
        if (GetComponentInChildren<Collider2D>())
        {
            GetComponentInChildren<Collider2D>().enabled = false;
            explotion.transform.position = GetComponentInChildren<Collider2D>().transform.position;
        }
        explotion.Init(End, 0.1f);
        asset.SetActive(false);
    }
}
