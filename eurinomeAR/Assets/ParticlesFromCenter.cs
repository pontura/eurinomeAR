using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesFromCenter : MonoBehaviour
{
    Camera cam;
    public VideogameParticle[] particles;
    public List<VideogameParticle> all;
    public float smooth = 0.5f;
    public int limitZ = 3;
    public Vector2 from_to_scale;
    public float scale_speed;

    void Start()
    {
        cam = Camera.main;
        Add();
    }

    void Add()
    {
        Invoke("Add", 2);
        VideogameParticle vp = Instantiate(GetParticle(), transform);
        vp.transform.localScale = new Vector3(from_to_scale.x, from_to_scale.x, from_to_scale.x);
        all.Add(vp);
    }

    void Update()
    {
        VideogameParticle toRemove = null;
        foreach (VideogameParticle v in all)
        {
            Vector3 pos = v.transform.position;
            Vector3 to = cam.transform.position;
            v.transform.position = Vector3.Lerp(pos, to, smooth * Time.deltaTime);
            if (Vector3.Distance(pos, to) < limitZ)
                toRemove = v;
            float _scale = v.transform.localScale.x + (scale_speed*Time.deltaTime);
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

    VideogameParticle GetParticle()
    {
        return particles[Random.Range(0,particles.Length)];
    }
}
