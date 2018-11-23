using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant_Dialog_Behavior : MonoBehaviour {
    public Merchant_Dialog Merchant_Dialog;

    public void StartDialog()
    {
        Merchant_Dialog.startDialog();
    }

}
[System.Serializable]
public class Merchant_Dialog : NPCDialog
{
    public override void startDialog()
    {
        node[3].reply[2].OnReplyEvent.AddListener(delegate { Inventory.DeleteSomeValueOfStackableItem("Деньги", 100); });
        base.startDialog();
    }
}