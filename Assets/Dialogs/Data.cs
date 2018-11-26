using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {
    private void Start()
    {
        GameStats.Dialogs.CurrentNode_NPC = new int[3];
        GameStats.Dialogs.CurrentNode_NPC[0] = 0;
        GameStats.Dialogs.CurrentNode_NPC[1] = 0;
        GameStats.Dialogs.CurrentNode_NPC[2] = 0;

    }
}


public static class GameStats
{
    public static class ItemCondition
    {
        public static bool Get_First_Expression_On_Alchemy = false;
        public static bool TakeFromBag = false;
        public static bool SeeLetter = false;
    }
    public static class Dialogs
    {
        public static bool TellMerchantAboutWomen = false;
        public static bool KnowAboutFlower = false;
        public static int[] CurrentNode_NPC;

    }
}
