using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour {

    private void Start()
    {
        instantThis();
    }
    public void instantThis()
    {
        Instantiate(TestStatic.prefab, TestStatic.Panel);
    }
}
