using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class DraggNDrop : MonoBehaviour {

    private Vector3 startPoint;
    Luggage luggage;
    Vector3 offset;
    void Start () {
        luggage = GameObject.Find("Maleta").GetComponent<Luggage>();
	}

    void OnMouseDown()
    {
        startPoint = transform.position;
        offset = gameObject.transform.position -
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    }

    void OnMouseDrag()
    {
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
    }
    void OnMouseUp()
    {
        if (!luggage.isCorrect())
            transform.position = startPoint;
        else Destroy(gameObject);
    }
}
