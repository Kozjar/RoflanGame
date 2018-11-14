using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message_Class : MonoBehaviour {
    public MessageSettingsAnother set;

    //Есть экземпляр класса настроек, который прикрепляется к пустому объекту на сцене.
    //В инспекторе мы указываем все необходимые настройки, которые будут применяться ко всем письмам.
    //Потом приравниваем все поля такого же, но статического класса к полям этого экземпляра.
    //Все это делается, чтобы не пришлось для каждого письма рачками в инспекторе указывать одни и те же панель меню, префаб и т.д.

    private void Start()
    {
        MessageSettingsAnotherStatic.FullTextArea = set.FullTextArea;
        MessageSettingsAnotherStatic._Content = set._Content;
        MessageSettingsAnotherStatic.Prefab = set.Prefab;
    }
}


/////////////////////Пока еще разбираюсь с этим//////////////////////////////////
//[CreateAssetMenu(fileName = "MessageSettings", menuName = "MessageSettings")]//
//public class MessageSettings : ScriptableObject                              //
//{                                                                            //
//    public GameObject Prefab;                                                //
//    public Transform _Content;                                               //
//    public GameObject FullTextArea;                                          //
//}                                                                            //
/////////////////////////////////////////////////////////////////////////////////


//Класс настроек
[System.Serializable]
public class MessageSettingsAnother
{
    public GameObject Prefab;
    public Transform _Content;
    public GameObject FullTextArea;
}

//Статический класс настроек, который используется для всех писем
public static class MessageSettingsAnotherStatic
{
    public static GameObject Prefab;
    public static Transform _Content;
    public static GameObject FullTextArea;
}

//Коллекция наших писем для будущей базы данных
public static class MessageInventory
{
    public static List<Message> MessageStack = new List<Message>();
}


[System.Serializable]
public class Message
{

    [TextArea]
    public string Text_Message; //Текст письма
    public Sprite Miniature; //миниатюра, которая будет отображаться в инвентаре

    //Добавляет письмо в инвентарь
    public void AddThisMessageToInventory()
    {
            MessageInventory.MessageStack.Add(this); //Добавляем новое письмо в коллекцию писем
            GameObject Clone;
            Clone = GameObject.Instantiate(MessageSettingsAnotherStatic.Prefab, MessageSettingsAnotherStatic._Content); //создаем пустую панель письма в меню писем
            Clone.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Miniature; //Задаем миниатюру письма
            Clone.transform.GetChild(1).GetComponent<Text>().text = GetMiniText(); //Задаем краткий текст
            Clone.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate { ShowMessage(Text_Message); }); //Задаем инструкции кнопки "Read"
    }

    //Показать полное письмо
    public void ShowMessage(string text)
    {
        MessageSettingsAnotherStatic.FullTextArea.transform.GetChild(0).GetComponent<Text>().text = text;
        MessageSettingsAnotherStatic.FullTextArea.SetActive(true);
    }

    //Функция, которая возвращает сокращенный текст письма
    public string GetMiniText()
    {
        string _Text; //Сокращенный текст письма
        int x = 52; //Колличество букв, которые будут показываться в сокращенном тексте письма

        if (Text_Message.Length < x)
            _Text = Text_Message.ToString();
        else
            _Text = Text_Message.Substring(0, x) + "...";

        return _Text;
    }
}
