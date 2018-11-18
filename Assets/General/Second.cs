using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Second : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<OnMouseDownTest>().enabled = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
