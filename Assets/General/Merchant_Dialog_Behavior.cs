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
        base.startDialog();
    }
}