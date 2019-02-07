// Скрипт для системы точек маршрута у NPC
// Скрипт вешается на флаг/пустой gameObject
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints_System : MonoBehaviour {

	public bool turnLeft = false;
	public bool turnRight = false;
	public bool turnDown = false;
	public bool turnUp = false;


	[Space]
	[Header("How long look away in seconds")]
	public int lookLeft = 0;
	public int lookRight = 0;
	public int lookUp = 0;
	public int lookDown = 0;
	
	[Space]
	public int Stop = 0;

	void Start () {
		
	}
	

	void Update () {
		//if (this.gameObject.GetComponent<MoveTest>().Points[PreviousFlag()].tag == "Right")
		//{
		//	sprite.flipX = false;
		//	lightAngle = 0;

		//}
		//else if(this.gameObject.GetComponent<MoveTest>().Points[PreviousFlag()].tag == "Left")
		//{
		//	sprite.flipX = true;
		//	lightAngle = -180;

		//}
		//else if (this.gameObject.GetComponent<MoveTest>().Points[PreviousFlag()].tag == "Up")
		//{
		//	lightAngle = 90;

		//}
		//else if (this.gameObject.GetComponent<MoveTest>().Points[PreviousFlag()].tag == "Down")
		//{

		//	lightAngle = -90;
		//}
	}
}
