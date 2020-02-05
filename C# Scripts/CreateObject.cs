using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateObject : MonoBehaviour
{
	/* 
	 * 
	 * Ta klasa Generuje obiekt z kamery gracza i go tworzy w tym przypadku budynek, ale mozliwe jest stworzenie jakiegokolwiek 
	 * innego obiektu z prefaba... 
	 * 
	 */

	public float minX = 5.0f, maxX = 50.0f; //Wartosci podane wedlug mapy
	public float minZ = 5.0f, maxZ = 50.0f; //Wartosci podane wedlug mapy
	public Vector3 position;
	public float moveSpeed = 1f;
	public GameObject prefab;
	public GameObject target;
	

	void Start()
	{
		
		for (int i = 0; i < 1; i++)
		{
			CreateOnScreenPosition();
		}

	}
	public void CreateOnScreenPosition()
	{
		var screenPoint = new Vector3(250, 250, 2); // Trzeba inaczej zdefiniowac zeby bylo po srodku
		var worldPos = Camera.main.ScreenToWorldPoint(screenPoint);
		target = Instantiate(prefab, worldPos, Quaternion.identity);
		SceneManager.BuildingSelected1 = target; //Przypisanie do zmiennej statycznej pozwoli nam przekazac obiekt do edycji juz na skrypcie samego obiektu. 
	}
}

