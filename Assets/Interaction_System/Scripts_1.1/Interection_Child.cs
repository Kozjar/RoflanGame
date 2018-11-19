using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interection_Child : MonoBehaviour {

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    private void Start()
    {
        cursorTexture = gameObject.GetComponentInParent<Interection_Main>().cursorTexture;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        if (collision.tag == "Player")
        {
            if (gameObject.GetComponentInParent<Interection_Main>().MouseOnObject)
                Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            gameObject.GetComponentInParent<Interection_Main>().InCollider = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
        if (collision.tag == "Player")
        {
            gameObject.GetComponentInParent<Interection_Main>().InCollider = false;
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
}
