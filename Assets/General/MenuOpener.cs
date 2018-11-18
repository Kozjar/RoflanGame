using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpener : MonoBehaviour {
    public GameObject Menu;
    private bool MenuActivity = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            MenuActivity = !MenuActivity;
            Menu.SetActive(MenuActivity);
        }
	}
}
