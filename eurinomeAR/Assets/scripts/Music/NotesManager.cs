using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NotesManager : MonoBehaviour
{
    public Material material;
    public NoteScript note;
    public states state;
    public enum states
    {
        WAIT,
        DRAWING,
        LOOP
    }
    public Transform container;
    public Camera cam;
    public float timer;
    public float timeToAdd = 0.2f;

    public List<NoteScript> all;
    public int noteID;
    public MusicSourceTarget msTarget;
    public float speed;
    public bool isOn;
    public MusicTrail musicTrail;

    private void Start()
    {
        cam = Camera.main;
    }
    public void Reset()
    {
        noteID = 0;
        state = states.DRAWING;
        all.Clear();
        Utils.RemoveAllChildsIn(container);
        timer = 0;
    }
    Vector3 rayPos;
    bool canDraw;
    void Update()
    {
        if (!isActiveAndEnabled) return;
        if (isOn)
        {
            rayPos = GetPosRayCast(Input.mousePosition);
            if (Input.GetMouseButtonDown(0) && rayPos != Vector3.zero)
            {
                canDraw = true;
                Reset();
                Draw();
            }
            else if (Input.GetMouseButton(0) && rayPos != Vector3.zero)
            {
                if(canDraw)
                    SavePoints();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                canDraw = false;
                Done();
            }
        }
        if (state == states.LOOP)
            Loop();
    }
    void SavePoints()
    {
        timer += Time.deltaTime;
        if (timer > timeToAdd)
            Draw();
    }
    private void Draw()
    {
        timer = 0;

        // Vector3 pos = GetPos();
        Vector3 pos = GetPosRayCast(Input.mousePosition);
        if (pos != Vector3.zero)
        {
            NoteScript ns = Instantiate(note, container);
            ns.Init(material, Input.mousePosition);
            all.Add(ns);
            ns.transform.position = pos;
        }
    }
    Vector3 GetPos()
    {
        Vector2 pos = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(pos);
        return ray.GetPoint(51);
    }
    Vector3 GetPosRayCast(Vector2 pos)
    {
        Ray ray = cam.ScreenPointToRay(pos);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray, 10000.0F);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if (hit.transform.gameObject.tag == "ARBoard")
                return hit.point;
        }
        return Vector3.zero;
    }
    void Done()
    {
        timer = 0;
        state = states.LOOP;
        noteID = 0;
        lastNote = -1;
    }
    int lastNote;
    void Loop()
    {
        timer += Time.deltaTime * speed;
        noteID = (int)Mathf.Floor(timer);
        if (noteID > all.Count - 1)
        {
            noteID = 0;
            timer = 0;
        }
        if (lastNote != noteID)
        {
            lastNote = noteID;
            PlayNote();
        }
    }
    void PlayNote()
    {
        if(noteID>all.Count-1) return;
        NoteScript ns = all[noteID];
        ns.SetOn();
        msTarget.SetValues(ns.pos);

        bool force = false;
        if (noteID == 0)
            force = true;

        musicTrail.Goto(ns.transform.localPosition, force);
    }
}
