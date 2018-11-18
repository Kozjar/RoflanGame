using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogScript : MonoBehaviour {
    public NPCDialog DefaultDialog;
    public Transform _DialogPanel;

   

    private void Start()
    {
    }
}



[System.Serializable]
public class NPCDialog
{
    public int NPC_ID;
    public Nod[] nod;
    public string name;
    public Transform DialogPanel;


    [System.Serializable]
    public class Nod
    {
        public string NPC_Text;
        public Reply[] reply;


        [System.Serializable]
        public class Reply
        {
            public delegate void ChangeDataBool();
            public ChangeDataBool _ChangeDataBool;

            

            public bool CloseDialog;
            public bool ShoudBeShowen;
            public string replyText;
            public int ToNod;
        }
    }

    public virtual void startDialog()
    {
        DialogPanel.gameObject.SetActive(true);
        DialogPanel.GetChild(0).GetComponent<Text>().text = name;
        putNod();
    }

    public void NextNode(Nod.Reply reply)   //Запускаем следующий нод
    {
        ChangeNod(reply.ToNod);   //Меняем нод в памяти
        try
        {
            reply._ChangeDataBool();
        }
        catch
        {
        }

        //if (reply.ChangeDataBool() != null)   //Меняем некоторое условие, если ответ это подразумевает
        //    reply.ChangeDataBool();
        //reply.ChangeDataBool();
        if (reply.CloseDialog)  //Закрываем диалог, если надо, или отображаем следующий нод
            DialogPanel.gameObject.SetActive(false);
        else putNod();   
    }

    public void ChangeNod(int NewNumber)    //Аргумент становится новым нодом, который записывается в память
    {
        GameStats.Dialogs.CurrentNod_NPC[NPC_ID] = NewNumber;
    }

    public void putNod()
    {
        int currentNod = GameStats.Dialogs.CurrentNod_NPC[NPC_ID];  //Записываем номер текущего нода в переменную для удобства
        DialogPanel.GetChild(1).GetComponent<Text>().text = nod[currentNod].NPC_Text;   //Отображаем текст npc
        Transform Buttons = DialogPanel.GetChild(2);    //Заносим панель с кнопками в отдельную переменную для удобства
        int i = 0;  //Индекс текущего ответа
        //Берем по порядку каждую кнопку и, если ответ с таким номером существует и должен быть показан, показываем саму кнопку и добавляем к ней Listener
        foreach (Transform child in Buttons)
        {
            try
            {
                Nod.Reply _reply = nod[currentNod].reply[i];
                if (!_reply.ShoudBeShowen)  //отключаем объект, если он не должен быть показан
                    child.gameObject.SetActive(false);
                else
                {
                    child.GetComponent<Button>().onClick.RemoveAllListeners();  //Удаляем все прошлые Listeners
                    child.gameObject.SetActive(true);   
                    child.GetChild(0).GetComponent<Text>().text = _reply.replyText;    //Текс ответа
                    child.GetComponent<Button>().onClick.AddListener(delegate { NextNode(_reply); });   //Задаем листенер перехода на следующий нод в зависимости от ответа номера этой кнопки
                }
            }
            catch
            {
                child.gameObject.SetActive(false);  //Отключаем кнопку, если ответа с таким номером не существует
            }
            i++;
        }

    }
}
