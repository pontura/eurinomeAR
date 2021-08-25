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
    }
    public void RefreshStats()
    {
        VideogameStats.StatData data = obstacles.videogame.stats.Get();
        speed = data.speed;
        foreach (GameObject go in assets)
            go.SetActive(false);
        assets[data.level - 1].SetActive(true);
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
        GetComponent<Collider2D>().enabled = false;
        explotion.Init(End, 0.1f);
        asset.SetActive(false);
    }
}
