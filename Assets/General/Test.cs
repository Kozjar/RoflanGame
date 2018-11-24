using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public Transform prefab;
    public Transform panel;
    private void Awake()
    {
        TestStatic.prefab = prefab;
        TestStatic.Panel = panel;
    }

}
public static class TestStatic
{
    public static Transform prefab;
    public static Transform Panel;
}