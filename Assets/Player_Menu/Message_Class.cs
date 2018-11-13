using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_Class : MonoBehaviour {

}

public static class MessageInventory
{
    public static List<Message> MessageStack = new List<Message>();
}


public class Message
{
    public GameObject Prefab;
    public string Text_Message;
    public Sprite Miniature;

    public void AddThisMessageToInventory()
    {
        MessageInventory.MessageStack.Add(this);
        //GameObject.Instantiate();
    }
}
