using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    public Camera mainCam;
    public GameObject brush;
    LineRenderer currentLineRenderer;
    Vector2 lastPos;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateBrush();
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos != lastPos)
            {
                AddPoint(mousePos);
                lastPos = mousePos;
            }
        }
        else
        {
            currentLineRenderer = null;
        }
    }

    void CreateBrush()
    {
        GameObject currentBrush = Instantiate(brush);
        currentBrush.GetComponent<Brush>().paperObject = gameObject;
        currentLineRenderer = currentBrush.GetComponent<LineRenderer>();
        Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }

    void AddPoint(Vector2 pointPos)
    {
        currentLineRenderer.positionCount++;
        int i = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(i, pointPos);
    }
}
