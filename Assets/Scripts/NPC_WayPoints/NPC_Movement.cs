// Скрипт Передвижения NPC по точкам(флагам).
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Movement : MonoBehaviour
{

    // Текущая точка маршрута
    internal int currentPoint;
    public bool Waiting = false;


    public Points points;
    private Transform[] TempBack;
    private Transform[] TempFoward;
    // Скорость и дистанция
    public float Speed = 0.0f;
    private float Distance = 0.0f;

    void Start()
    {

        int j = 0;
        TempBack = new Transform[points.objects.Length];
        TempFoward = new Transform[points.objects.Length];

        // Переверуть массив
        for (int i = points.objects.Length - 1; i >= 0; i--)
        {
            TempBack[j] = points[i];
            j++;
        }
        for (int i = 0; i <= points.objects.Length - 1; i++)
        {
            TempFoward[i] = points[i];
        }



    }

    void Update()
    {
        if (currentPoint == points.objects.Length)
        {
            for (int i = 0; i < points.objects.Length; i++)
            {
                points[i] = TempBack[i];
            }

            currentPoint = 0;


        }
        else if (currentPoint == 0)
        {
            for (int i = 0; i < points.objects.Length; i++)
            {
                points[i] = TempFoward[i];

            }
        }

        float currentDistance = Vector3.Distance(transform.position, points[currentPoint].position);

        if (currentDistance <= Distance)
        {
            if (points[currentPoint].tag == "Wait")
            {
                if (!Waiting)
                {
                    StartCoroutine(stop());
                    Waiting = true;
                }
            }
            else
                currentPoint++;
        }

        Vector3 directionToPoint = points[currentPoint].position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, Speed * Time.deltaTime);
    }

    IEnumerator stop()
    {
        yield return new WaitForSeconds(4);
        Waiting = false;
        currentPoint++;
    }



}
[System.Serializable]
public class Points
{
    public Transform[] objects;

    [HideInInspector]
    public int Length;

    public Points(int Size)
    {
        objects = new Transform[Size];
        Length = Size;
    }

    public Transform this[int index]
    {
        set
        {
            objects[index] = value;
        }

        get
        {
            if (index == objects.Length)
                return objects[index - 1];
            else return objects[index];
        }
    }
}