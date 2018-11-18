using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_1 : MonoBehaviour {
    public NPC_1_Dialog npc1_dialog;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate { npc1_dialog.startDialog(); });
    }
}


[System.Serializable]
public class NPC_1_Dialog : NPCDialog
{
    public override void startDialog()
    {
        nod[0].reply[1].ShoudBeShowen = GameStats.Dialogs.FackedRedSword;
        base.startDialog();
    }
}
