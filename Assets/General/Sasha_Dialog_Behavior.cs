using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sasha_Dialog_Behavior : MonoBehaviour {

    public Sasha_Dialog Sasha_Dialog;

    private void Start()
    {
        //GetComponent<Button>().onClick.AddListener(delegate { npc1_dialog.startDialog(); });
    }
    public void StartDialog()
    {
        Sasha_Dialog.startDialog();
    }
}


[System.Serializable]
public class Sasha_Dialog : NPCDialog
{
    public override void startDialog()
    {
        nod[0].reply[2].ShoudBeShowen = Inventory.FindItemWithName("Кристалл");
        nod[2].reply[1].ShoudBeShowen = Inventory.FindItemWithName("Кристалл");
        base.startDialog();
    }
}
