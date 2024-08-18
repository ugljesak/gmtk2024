using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    public Camera mainCam;
    private LineRenderer lineRenderer;
    private Rigidbody2D rb;
    public GameObject paperObject;
    private Paper paper;

    void Start()
    {
        mainCam = Camera.main;
        lineRenderer = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        transform.position = mainCam.ScreenToWorldPoint(Input.mousePosition);
    }
}
