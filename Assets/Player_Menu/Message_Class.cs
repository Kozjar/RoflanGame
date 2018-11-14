using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message_Class : MonoBehaviour {

}

public static class MessageInventory
{
    public static List<Message> MessageStack = new List<Message>();
}


[System.Serializable]
public class Message
{
    public GameObject Prefab;
    public Transform _Content;
    public GameObject FullTextArea;

    [TextArea]
    public string Text_Message;
    public Sprite Miniature;

    public void AddThisMessageToInventory()
    {
        MessageInventory.MessageStack.Add(this);
        GameObject Clone;
        Clone = GameObject.Instantiate(Prefab, _Content);
        Clone.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Miniature;
        Clone.transform.GetChild(1).GetComponent<Text>().text = GetMiniText();
        Clone.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate { FullTextArea.SetActive(true); });
        Clone.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate { ShowMessage(Text_Message); });
    }

    public void ShowMessage(string text)
    {
        FullTextArea.transform.GetChild(0).GetComponent<Text>().text = text;
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
