using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerClass : MonoBehaviour {
    //public GameObject Speaker1, Speaker2;
    public string Name;
    public Speech[] replics;
    public int textSize = 14;
    public Color textColor = Color.white;
    public Font textFont;

    private IEnumerator a;
    [HideInInspector]
    public string CurrentSpeech = null;
    public SpeachTriggerCollider triggerCollider;
    public SpeakingManager Manager;

    private SpriteRenderer SpriteRend;
    private void Start()
    {
        SpriteRend = gameObject.GetComponent<SpriteRenderer>();
        if (triggerCollider != null)
            triggerCollider.speechOutput += ShowMessage;
        //StartCoroutine(ShowMessageCoroutine("Leather Man"));
    }
    private void Update()
    {
        //textPixelHeight = GetComponent<SpriteRenderer>().sprite.rect.height * transform.localScale.y / 2.0f;
    }

    private void OnGUI()
    {
        if (CurrentSpeech != null)
        {
            GUI.depth = 9999;

            GUIStyle style = new GUIStyle();
            style.fontSize = textSize;
            style.richText = true;
            if (textFont) style.font = textFont;
            style.normal.textColor = textColor;
            style.alignment = TextAnchor.MiddleCenter;

            float YOffset = (SpriteRend.sprite.rect.height - SpriteRend.sprite.pivot.y) / 100 * transform.localScale.y;
            Vector3 worldPosition = new Vector3(transform.position.x, transform.position.y + YOffset, transform.position.z);
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
            screenPosition.y = Screen.height - screenPosition.y;

            GUI.Label(new Rect(screenPosition.x, screenPosition.y - textSize, 0, 0), CurrentSpeech, style);
        }
    }
    public void ShowSelfMessage(int ID)
    {
        StartCoroutine(ShowMessageCoroutine(replics[ID], this));
    }
    public void ShowMessage(SpeakerWithIndex replic)
    {
        StartCoroutine(ShowMessageCoroutine(replic.speaker.replics[replic.ID], this));
    }
    public IEnumerator ShowMessageCoroutine(Speech replic, SpeakerClass speaker)
    {
        speaker.CurrentSpeech = replic.text;
        yield return new WaitForSeconds(replic.Timer);
        speaker.CurrentSpeech = null;
        if (replic.ConnectedWith != null)
            replic.ConnectedWith.StartCoroutine(ShowMessageCoroutine(replic.ConnectedWith.replics[replic.ConnectedID], replic.ConnectedWith));
        yield return null;
    }
}
