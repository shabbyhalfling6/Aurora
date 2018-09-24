using UnityEngine;
using System.Collections;

public class ScrollPlanet : MonoBehaviour 
{

	public float scrollSpeed;
	private Vector3 startPosition;
	
	void Start ()
	{
		startPosition = transform.position;
	}
	
	void Update ()
	{
		float newPosition = Time.time * scrollSpeed;
		transform.position = startPosition + Vector3.back * newPosition;
	}
}