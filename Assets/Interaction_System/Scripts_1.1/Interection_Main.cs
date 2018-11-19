using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interection_Main : MonoBehaviour {
    [HideInInspector]
    public bool InCollider = false; //Находится ли игрок в зоне взаимодействия
    [HideInInspector]
    public bool MouseOnObject = false; //Наведена ли мышь на объект
    //Событие, которое будет выполняться при нажатии
    public UnityEvent OnClickEvent;
    //Настройки курсора
    public Texture2D cursorTexture; 
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;


    void OnMouseEnter()
    {
        MouseOnObject = true;
        //Меняем курсор при наведении на предмет, если игрок находится в зоне взаимодействия
        if (InCollider)
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
    void OnMouseExit()
    {
        MouseOnObject = false;
        Cursor.SetCursor(null, Vector2.zero, cursorMode); //Возвращаем курсор, когда мышь покидает границы объекта

    }

    private void OnMouseDown()
    {
        //Выполняется событие, когда нажимаем на объект, если игрок в зоне действия
        if (InCollider)
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
            OnClickEvent.Invoke();
        }
    }

    public void DestroyThisObj()
    {
        Destroy(this.gameObject);
    }
}
