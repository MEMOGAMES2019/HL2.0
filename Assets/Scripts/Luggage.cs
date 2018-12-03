using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luggage : MonoBehaviour {

    public string[] ropa;
    bool correct = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int i = 0;
        while (i < ropa.Length && collision.gameObject.name != ropa[i]) { i++; }
        if(i < ropa.Length)
            correct = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        correct = false;
    }
    
    public bool isCorrect()
    {
        if (correct)
        {
            correct = false;
            return true;
        }
        else
            return false;
    }
}
