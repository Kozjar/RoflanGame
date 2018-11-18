using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_2 : MonoBehaviour {
    public NPC_2_Dialog npc2_dialog;

    private void Start()
    {
        npc2_dialog.nod[2].reply[1]._ChangeDataBool = new NPCDialog.Nod.Reply.ChangeDataBool(Change_FackedRedSword);
        GetComponent<Button>().onClick.AddListener(delegate { npc2_dialog.startDialog(); });
    }
    public void Change_FackedRedSword()
    {
        GameStats.Dialogs.FackedRedSword = !GameStats.Dialogs.FackedRedSword;
    }
}


[System.Serializable]
public class NPC_2_Dialog : NPCDialog
{
    

}
