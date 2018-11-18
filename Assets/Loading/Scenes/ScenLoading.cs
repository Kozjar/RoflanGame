using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenLoading : MonoBehaviour {

    public int count=0;

    [Header("Загруженная сцена")]
    public int sceneID;
    [Header("Остальные объекты")]
    public Image loadingImg;
    public Text progressText, KeyDown;
    public GameObject anim;
    public Text Speaker;
    // private AsyncOperation Cheker;
    
    private void Awake()
    {
        Debug.Log("Запустилась анимка");
       // this.anim.Play();
    }
    void Start ()
    {
        StartCoroutine(AsynsLoad());
        StartCoroutine(PrintMessage(Speaker.text));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) & count == 0)
        {
            Debug.Log("Запустилась 1");
            count++;
            anim.SetActive(false);
            StopCoroutine("PrintMessage");
            PrintMessage_1(Speaker.text);
        }
    }

    IEnumerator AsynsLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
        while (operation.isDone == false) {
            operation.allowSceneActivation = false;
            float progress = operation.progress / 0.9f;
            loadingImg.fillAmount = progress;
            progressText.text = string.Format("{0:0}%", progress * 100);
            if (Input.GetKeyDown(KeyCode.F) & count == 1)
            {
                Debug.Log("Запустилась 2");
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    IEnumerator PrintMessage(string message)
    {
            Debug.Log("Запустилась 0 текст");
            Speaker.text = "";
            for (int i = 0; i < message.Length; i++)
            {
                Speaker.text += message[i];
                yield return new WaitForSeconds(.0001f);
            }
    }

    public void PrintMessage_1(string message)
    {
        Debug.Log("Запустилась 1 текст");
        Speaker.text = "";
        Speaker.text = message;
    }

}