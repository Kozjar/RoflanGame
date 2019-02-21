﻿// Данный скрипт представляет собой систему поле видимости противника.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rays : MonoBehaviour
{

    // Количество лучей
    [SerializeField]
    [Range(1, 90)]
    public int numberOfRays;

    // Угол падения лучей
    [SerializeField]
    [Range(-360, 360)]
    public float lightAngle = 0;

    // Расстояние между лучами
    [SerializeField]
    [Range(0, 360)]
    public float lightCone = 90;

    private float originOffset = 0.5f;

    public float raycastMaxDistance = 10f;

    [SerializeField]
    public float lightSourceSize = 0;

    private Waypoints_System wp_s;


    public LayerMask mask = 11;


    private NPC_Movement npc_Movement;
    void Start()
    {
        npc_Movement = gameObject.GetComponent<NPC_Movement>();



    }
    void Update()
    {
        if (!npc_Movement.Waiting)
        {
            lightAngle = Vector2.Angle(npc_Movement.points[npc_Movement.currentPoint].transform.position - transform.position, Vector2.right);
            lightAngle = lightAngle * Mathf.Sign(npc_Movement.points[npc_Movement.currentPoint].transform.position.y - transform.position.y);
        }
        else
        {
            wp_s = npc_Movement.points[npc_Movement.currentPoint].GetComponent<Waypoints_System>();
            StartCoroutine(LookAround());
        }
        CreateVectors();
    }

    IEnumerator LookAround()
    {
        if(wp_s.lookLeft>0)
        while (lightAngle <= 180)
        {
            yield return new WaitForSeconds(0);
            lightAngle += (wp_s.lookLeft/10f);
            //StartCoroutine(Waiting());
        }
        else if (wp_s.lookRight > 0)
            while (lightAngle <= 0 || lightAngle <= 360)
            {
                yield return new WaitForSeconds(0);
                lightAngle += (wp_s.lookRight / 10f);
            }


    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(npc_Movement.points[npc_Movement.currentPoint].GetComponent<Waypoints_System>().lookLeft);
    }
    private void CreateVectors()
    {
        float RaySpacing = lightCone / numberOfRays;
        float initialAngle = lightAngle - (lightCone / 2);

        Vector3 initialLocation = transform.position + (new Vector3(Mathf.Cos(Mathf.Deg2Rad * (lightAngle - 90)), Mathf.Sin(Mathf.Deg2Rad * (lightAngle - 90))) * lightSourceSize / 2);
        Vector3 locationOffset = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (lightAngle - 90)), Mathf.Sin(Mathf.Deg2Rad * (lightAngle - 90))) * lightSourceSize / numberOfRays;

        for (int i = 0; i < numberOfRays; i++)
        {
            Vector3 origin = initialLocation - (locationOffset * i);
            Vector3 direction = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (i * RaySpacing + initialAngle)) * raycastMaxDistance, Mathf.Sin(Mathf.Deg2Rad * (i * RaySpacing + initialAngle)) * raycastMaxDistance);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, raycastMaxDistance);
            if (hit)
            {
                Debug.DrawRay(transform.position, (direction * hit.distance / raycastMaxDistance), Color.yellow);
            }
            else
            {
                Debug.DrawRay(transform.position, direction, Color.red);
            }
        }

    }

}