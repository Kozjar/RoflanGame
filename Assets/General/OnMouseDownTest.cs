using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnMouseDownTest : MonoBehaviour {
    //[HideInInspector]
    public bool InCollider = false;
    //[HideInInspector]
    public bool MouseOnObject = false;
    // Use this for initialization
    public UnityEvent OnClickEvent;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;


    private void Start()
    {
           
    }
    void OnMouseEnter()
    {
        MouseOnObject = true;
        if (InCollider)
        {
            
            Debug.Log("MouseEnter");
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }
    }
    void OnMouseExit()
    {

        MouseOnObject = false;
        Debug.Log("MouseExit");
        Cursor.SetCursor(null, Vector2.zero, cursorMode);

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log("Enter");
    //    if (collision.tag == "Player")
    //    {
    //        if(MouseOnObject)
    //            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    //        InCollider = true;
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.Log("Exit");
    //    if (collision.tag == "Player")
    //    {
    //        InCollider = false;
    //        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    //    }
    //}

    private void OnMouseDown()
    {
        Debug.Log("MouseDown");
        if (InCollider)
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
            OnClickEvent.Invoke();
            Destroy(this.gameObject);
            Debug.Log("InCollider");
        }
    }
}
