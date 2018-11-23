using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour {
	public GameObject Inv;
	public GameObject player;
	public GameObject Staticdata;
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Player")
		{
			DontDestroyOnLoad(Inv);
			DontDestroyOnLoad(player);
			DontDestroyOnLoad(Staticdata);
			SceneManager.LoadScene(2);
		}
	}
		
	
}
