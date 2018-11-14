using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message_Class : MonoBehaviour {
    public MessageSettingsAnother set;

    private void Start()
    {
        MessageSettingsAnotherStatic.FullTextArea = set.FullTextArea;
        MessageSettingsAnotherStatic._Content = set._Content;
        MessageSettingsAnotherStatic.Prefab = set.Prefab;
    }
}

[CreateAssetMenu(fileName = "MessageSettings", menuName = "MessageSettings")]
public class MessageSettings : ScriptableObject
{
    public GameObject Prefab;
    public Transform _Content;
    public GameObject FullTextArea;
}

[System.Serializable]
public class MessageSettingsAnother
{
    public GameObject Prefab;
    public Transform _Content;
    public GameObject FullTextArea;
}

public static class MessageSettingsAnotherStatic
{
    public static GameObject Prefab;
    public static Transform _Content;
    public static GameObject FullTextArea;
}

public static class MessageInventory
{
    public static List<Message> MessageStack = new List<Message>();
}


[System.Serializable]
public class Message
{

    [TextArea]
    public string Text_Message;
    public Sprite Miniature;

    public void AddThisMessageToInventory()
    {
            MessageInventory.MessageStack.Add(this);
            GameObject Clone;
            Clone = GameObject.Instantiate(MessageSettingsAnotherStatic.Prefab, MessageSettingsAnotherStatic._Content);
            Clone.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Miniature;
            Clone.transform.GetChild(1).GetComponent<Text>().text = GetMiniText();
            Clone.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate { MessageSettingsAnotherStatic.FullTextArea.SetActive(true); });
            Clone.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate { ShowMessage(Text_Message); });
    }

    public void ShowMessage(string text)
    {
            MessageSettingsAnotherStatic.FullTextArea.transform.GetChild(0).GetComponent<Text>().text = text;
    }

    public string GetMiniText()
    {
        string _Text;
        int x = 52;
        if (Text_Message.Length < x)
            _Text = Text_Message.ToString();
        else
            _Text = Text_Message.Substring(0, x) + "...";
        return _Text;
    }
}
