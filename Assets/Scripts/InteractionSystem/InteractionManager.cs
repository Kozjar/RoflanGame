using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour {
    IInteraction[] Interactions = new IInteraction[3];
    private GameObject InteractableObj, PrevObj;
    public bool DrawingInteractions = false;
    public int textSize = 14;
    public Color textColor = Color.white;

    private SpriteRenderer SpriteRend;

    private void Start()
    {
        
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.E) && Interactions[0] != null)
            Interactions[0].Action();
        if (Input.GetKeyDown(KeyCode.Q) && Interactions[1] != null)
            Interactions[1].Action();
        if (Input.GetKeyDown(KeyCode.R) && Interactions[2] != null)
            Interactions[2].Action();
    }
    //Вызывается, когда мы подходим к объекту, с которым возможны взаимодействия
    public void StartInteraction(GameObject o)
    {
        if (PrevObj == o)
        {
            Debug.Log("Look at same obj");
            return;
        }
        Interactions = new IInteraction[3]; //обнуляем массив
        PrevObj = o;
        InteractableObj = o; //Запоминаем объект, с которым в данный момент может быть взаимодействие
        SpriteRend = InteractableObj.GetComponent<SpriteRenderer>();
        Debug.Log("InteractableObj.GetComponent<SpriteRenderer>().size.y = " + InteractableObj.GetComponent<SpriteRenderer>().size.y);
        Debug.Log("height = " + InteractableObj.GetComponent<SpriteRenderer>().sprite.rect.height);
        Debug.Log("InteractableObj.GetComponent<SpriteRenderer>().sprite.pivot.y = " + InteractableObj.GetComponent<SpriteRenderer>().sprite.pivot.y);
        Debug.Log("InteractableObj.transform.localScale.y = " + InteractableObj.transform.localScale.y);
        Debug.Log("InteractableObj.transform.position.y = " + InteractableObj.transform.position.y);
        Debug.Log("MicroSum = " + (1 - SpriteRend.sprite.pivot.y / SpriteRend.sprite.rect.height));
        //Debug.Log("* Size = " + ((InteractableObj.GetComponent<SpriteRenderer>().size.y - InteractableObj.GetComponent<SpriteRenderer>().sprite.pivot.y / 100) * InteractableObj.transform.localScale.y));
        Debug.Log("Sum = " + SpriteRend.size.y * (1 - SpriteRend.sprite.pivot.y / SpriteRend.sprite.rect.height) * InteractableObj.transform.localScale.y);
        //Debug.Log("Sum2 = " + -4.59f + (InteractableObj.GetComponent<SpriteRenderer>().size.y - InteractableObj.GetComponent<SpriteRenderer>().sprite.pivot.y / 100) * InteractableObj.transform.localScale.y);
        DrawingInteractions = true; //Рисуем над объектом меню взаимодействий
        IInteraction[] interactions = o.GetComponents<IInteraction>(); //Берем у объекта все взаимодействия, которые к нему прикреплены
        int i = 0;
        foreach(MonoBehaviour interaction in interactions)
        {
            if (interaction.enabled == true) //Проверяем активно ли взаимодействие и если да, заносим его в основной массив 
            {
                Interactions[i] = (IInteraction)interaction;
                i++;
            }
        }
    }
    //Вызывается, когда мы уже не можем совершать взаимодействия с объектом
    public void CloseInteraction()
    {
        DrawingInteractions = false;
        PrevObj = null;
        //Interactions = new IInteraction[3]; //обнуляем массив
    }

    private void OnGUI()
    {
        if (DrawingInteractions)
        {
            drawInteractions();
        }
    }
    private void drawInteractions()
    {
        int j = 1;
        string text = "";
        //берем позицию вверху поцентру объекта
        
        float YOffset = (SpriteRend.sprite.rect.height - SpriteRend.sprite.pivot.y) / 100 * InteractableObj.transform.localScale.y;
        Vector3 worldPosition = new Vector3(InteractableObj.transform.position.x,
                                            InteractableObj.transform.position.y + YOffset, 
                                            InteractableObj.transform.position.z);
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition); //Переводим мировые координаты юньки в координаты экрана
        screenPosition.y = Screen.height - screenPosition.y; //Просто более правильная позиция
        for (int i = Interactions.Length - 1; i >= 0; i--)
        {
            if (Interactions[i] != null)
            {
                switch (i)
                {
                    case 0:
                        text = "E - " + Interactions[i].name;
                        break;
                    case 1:
                        text = "Q - " + Interactions[i].name;
                        break;
                    case 2:
                        text = "R - " + Interactions[i].name;
                        break;
                }
                GUIStyle style = new GUIStyle();
                style.fontSize = textSize;
                style.richText = true;
                style.normal.textColor = textColor;
                style.alignment = TextAnchor.MiddleCenter;
                //Выводим текст каждого взаимодействия на необходимой высоте
                GUI.Label(new Rect(screenPosition.x, screenPosition.y - textSize * 1.5f * j, 0, 0), text, style);
                j++;
            }
        }
    }
}