using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour {
	public GameObject Inv;
	public GameObject player;
	public GameObject Staticdata;
    public GameObject EventSystem;
    private void Start()
    {
        DontDestroyOnLoad(Inv);
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(Staticdata);
        DontDestroyOnLoad(EventSystem);
    }
    void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Player")
		{

            SceneManager.LoadScene(2);
		}
	}
		
	
}
