using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenLoading : MonoBehaviour
{

    public int count = 0;

    [Header("Загруженная сцена")]
    public int sceneID;
    [Header("Остальные объекты")]
    public Text progressText, KeyDown_F, KeyDown_E;
    public Text Speaker;
    
    private Coroutine a;//...объект обращение к карутину

    private string FullText;
    private void Awake()
    {
        Debug.Log("Запустилась анимка");
        FullText = Speaker.text;
        // this.anim.Play();
    }
    void Start()
    {
        StartCoroutine(AsynsLoad());
        a = StartCoroutine(PrintMessage(FullText));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Нажата Е");
            KeyDown_E.gameObject.SetActive(false);
            KeyDown_F.gameObject.SetActive(true);
            count++;
            StopCoroutine(a);
            PrintMessage_1(FullText);
        }
    }

    IEnumerator AsynsLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
        while (operation.isDone == false)
        {
            operation.allowSceneActivation = false;
            float progress = operation.progress / 0.9f;
            progressText.text = string.Format("{0:0}%", progress * 100);
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Запустилась 2");
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    IEnumerator PrintMessage(string message)
    {
        Debug.Log("Стартанула куротина вывода текста");
        Speaker.text = "";
        for (int i = 0; i < message.Length; i++)
        {
            Speaker.text += message[i];
            if (Speaker.text.Length == message.Length)
            {
                KeyDown_F.gameObject.SetActive(true);
                KeyDown_E.gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(.0001f);
        }
    }

    public void PrintMessage_1(string message)
    {
        Debug.Log("Вывод всего текста");
        Speaker.text = "";
        Speaker.text = message;
    }

}