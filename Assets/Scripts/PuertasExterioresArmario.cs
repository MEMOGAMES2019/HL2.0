using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertasExterioresArmario : MonoBehaviour {

    public GameObject parteAbierta;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
            parteAbierta.gameObject.SetActive(true);
        }
    }
}
