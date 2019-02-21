using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiverDialog_beh : MonoBehaviour, OriginDialog
{
    public QuestGiverDialog questGiverDialog;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void startDialog()
    {
        questGiverDialog.startDialog();
    }

    [System.Serializable]
    public class QuestGiverDialog : NPCDialog
    {

    }
}
