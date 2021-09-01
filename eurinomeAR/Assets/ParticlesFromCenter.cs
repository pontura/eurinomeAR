using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesFromCenter : MonoBehaviour
{
    Camera cam;
    public VideogameParticle[] particles;
    public VideogameParticle[] smallParticles;
    public List<VideogameParticle> all;
    public float smooth = 0.5f;
    public int limitZ = 3;
    public Vector2 from_to_scale;
    public float scale_speed;
    public Vector3 camOffset;
    public float delay = 1;
    public float delaySmall = 1f;
    Transform container;

    void Start()
    {
        container = GameObject.Find("particlesContainer").transform;
        all.Clear();
        cam = Camera.main;
        Add();
        Invoke("AddSmall", delaySmall);
    }

    void Add()
    {
        Invoke("Add", delay);
        VideogameParticle vp = Instantiate(particles[Random.Range(0, particles.Length)], transform);
        vp.transform.SetParent(container);
        vp.transform.localScale = new Vector3(from_to_scale.x, from_to_scale.x, from_to_scale.x);
        all.Add(vp);
    }
    void AddSmall()
    {
        Invoke("AddSmall", delaySmall);
        VideogameParticle vp = Instantiate(smallParticles[Random.Range(0, smallParticles.Length)], transform);
        vp.transform.SetParent(container);
        vp.transform.localScale = new Vector3(from_to_scale.x, from_to_scale.x, from_to_scale.x);
        all.Add(vp);
    }

    void Update()
    {
        VideogameParticle toRemove = null;
        foreach (VideogameParticle v in all)
        {
            Vector3 pos = v.transform.localPosition;
            Vector3 to = camOffset;
            v.transform.localPosition = Vector3.Lerp(pos, to, smooth * Time.deltaTime);
            if (Vector3.Distance(pos, to) < limitZ)
                toRemove = v;
            float _scale = v.transform.localScale.x + (scale_speed * Time.deltaTime);
            if (_scale > from_to_scale.y)
                _scale = from_to_scale.y;
            v.transform.localScale = new Vector3(_scale, _scale, _scale);
        }
        if(toRemove != null)
        {
            all.Remove(toRemove);
            Destroy(toRemove.gameObject);
        }
    }
}
