// Скрипт для системы точек маршрута у NPC
// Скрипт вешается на флаг/пустой gameObject
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints_System : MonoBehaviour {

    // Флаг поворота в одну из сторон
	public bool turnLeft = false;
	public bool turnRight = false;
	public bool turnDown = false;
	public bool turnUp = false;

    // Сколько в секунду смотреть в определённую сторону
	public int lookLeft = 0;
	public int lookRight = 0;
	public int lookUp = 0;
	public int lookDown = 0;
	
    // Сколько в секундах стоять на данной точке
	public int Stop = 0;

    void Start()
    {

    }

	void Update () {

	}
}
