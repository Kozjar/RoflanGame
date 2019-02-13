// Данный скрипт представляет собой систему поле видимости противника.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rays : MonoBehaviour {

	// Количество лучей
	[SerializeField]
	[Range(1,90)]
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

    private NPC_Movement npc_movement;


    public LayerMask mask = 11;

	void Start () {

        npc_movement = gameObject.GetComponent<NPC_Movement>();


    }
	void Update () {

        ChangeSideRewiev();
        CreateVectors();
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
			RaycastHit2D hit = Physics2D.Raycast(origin, direction, raycastMaxDistance);
			if (hit)
			{
				Debug.DrawRay(origin, (direction * hit.distance / raycastMaxDistance),Color.yellow);
			}
			else
			{
				Debug.DrawRay(origin, direction,Color.red);
			}
		}

	}

    private void ChangeSideRewiev()
    {
        if (npc_movement.points[npc_movement.currentPoint].GetComponent<Waypoints_System>().turnRight == true)
        {

            lightAngle = 0;

        }
        else if (npc_movement.points[npc_movement.currentPoint].GetComponent<Waypoints_System>().turnLeft == true)
        {

            lightAngle = 180;

        }
        else if (npc_movement.points[npc_movement.currentPoint].GetComponent<Waypoints_System>().turnDown == true)
        {

            lightAngle = 270;

        }
        else
            lightAngle = 90;
    }

    public int PreviousFlag()
    {
        if (gameObject.GetComponent<NPC_Movement>().currentPoint == 0)
            return gameObject.GetComponent<NPC_Movement>().points.objects.Length - 1;
        else
            return gameObject.GetComponent<NPC_Movement>().currentPoint - 1;

    }

}
