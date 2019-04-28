using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private Transform planetPos;
    private Vector2 initialPosition;
    private Vector2 mousePosition;
    private float deltaX, deltaY;

    void Awake()
    {
        planetPos = GetComponent<Transform>();
        initialPosition = transform.position;
    }

    private void OnMouseDown()
    {
        deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
    }

    private void OnMouseUp()
    {
        transform.position = mousePosition;
    }
}
