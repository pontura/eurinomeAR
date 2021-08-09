using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingScreen : MonoBehaviour
{
    public Camera m_camera;
    public GameObject brush;
    public Transform brushesContainer;
    LineRenderer currentLineRenderer;
    public Color color;

    Vector3 lastPos;
    public bool isOn;

    void ChangeColor(Color color)
    {
        this.color = color;
    }
    public void Init(Sprite s)
    {
        gameObject.SetActive(true);
        isOn = true;
        this.color = Color.red;
    }
    private void Update()
    {
        if (!isOn) return;
        Drawing();
    }
    public void SetOff()
    {
        isOn = false;
        Utils.RemoveAllChildsIn(brushesContainer);
        gameObject.SetActive(false);
    }
    void Drawing()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateBrush();
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            PointToMousePos();
        }
        else
        {
            currentLineRenderer = null;
        }
    }
    GameObject brushInstance;
    void CreateBrush()
    {
        brushInstance = Instantiate(brush, brushesContainer);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        currentLineRenderer.startColor = color;
        currentLineRenderer.endColor = color;
        //because you gotta have 2 points to start a line renderer, 
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);

    }

    void AddAPoint(Vector2 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }

    void PointToMousePos()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 start = Camera.main.transform.position;
        Vector3 mousePos = ray.GetPoint(51);


        if (lastPos != mousePos)
        {
            AddAPoint(mousePos);
            lastPos = mousePos;
        }
    }
    public void Undo()
    {
        if (brushInstance != null)
        {
            Utils.RemoveAllChildsIn(brushesContainer);
            currentLineRenderer = null;
        }
    }

}
