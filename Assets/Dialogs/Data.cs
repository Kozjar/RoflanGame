using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {
    private void Start()
    {
        GameStats.Dialogs.CurrentNod_NPC = new int[2];
        GameStats.Dialogs.CurrentNod_NPC[0] = 0;
        GameStats.Dialogs.CurrentNod_NPC[1] = 0;

    }
}


[System.Serializable]
public static class GameStats
{
    [System.Serializable]
    public static class Dialogs
    {
        public static bool FackedRedSword;
        public static int[] CurrentNod_NPC;

    }
}
