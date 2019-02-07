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
	public float lightAngle = -90;

	// Расстояние между лучами
	[SerializeField]
	[Range(0, 360)]
	public float lightCone = 90;

	private float originOffset = 0.5f;

	public float raycastMaxDistance = 10f;

	[SerializeField]
	public float lightSourceSize = 0;

    public LayerMask mask = 11;

	void Start () {

        Debug.Log(LayerMask.LayerToName(mask));
	
	}
	void Update () {
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
	//public int PreviousFlag()
	//{
	//	if (this.gameObject.GetComponent<MoveTest>()._currentPoint == 0)
	//		return this.gameObject.GetComponent<MoveTest>().Points.objects.Length - 1;
	//	else
	//		return this.gameObject.GetComponent<MoveTest>()._currentPoint - 1;
	//}
}
