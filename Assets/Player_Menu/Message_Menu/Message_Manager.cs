using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_Manager : MonoBehaviour {

    public Transform ContentField;
    public GameObject MessageSlotPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void AddNewMessage()
    {
        Instantiate(MessageSlotPrefab, ContentField);
    }
}
