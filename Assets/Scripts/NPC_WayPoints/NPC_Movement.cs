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
    private Waypoints_System wp_s;

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
        // Если enemy дошёл до последнего поинта то переворачиваем массив и он(enemy) идёт обратно
        if (currentPoint == points.objects.Length)
        {
            for (int i = 0; i < points.objects.Length; i++)
            {
                points[i] = TempBack[i];
            }

            currentPoint = 0;


        }// Аналогично но только вперед
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
                    wp_s = points[currentPoint].GetComponent<Waypoints_System>();
                    // Остановится на заданное кол-во секунд
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
       
        yield return new WaitForSeconds(wp_s.lookLeft+wp_s.lookRight+wp_s.lookUp+wp_s.lookDown);
        Waiting = false;
        currentPoint++;
    }



}
// Чисто шоб за границы массив не выходил
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