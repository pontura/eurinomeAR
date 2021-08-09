using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    [SerializeField] Animation anim;
    public Vector2 pos;
    [SerializeField] public MeshRenderer meshRenderer;

    public void Init(Material mat, Vector2 pos)
    {
        this.pos = pos;
        meshRenderer.material = mat;
    }
    public void SetOn()
    {
        anim.Play();
    }

}
