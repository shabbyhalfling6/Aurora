using UnityEngine;
using System.Collections;

public class PlanetRotate : MonoBehaviour {

	private Transform myTransform;
	private Vector3 currentRotate;
	public float rotationSpeedX = 10f;

	public float rotationSpeedZ = -10f;
	public float rotationSpeedY = 10;

	// Use this for initialization
	void Start () {

		myTransform = this.transform;
		currentRotate = myTransform.rotation.eulerAngles;
	
	}
	
	// Update is called once per frame
	void Update () {
		currentRotate.x += rotationSpeedX * Time.deltaTime;
		currentRotate.y += rotationSpeedY * Time.deltaTime;
		currentRotate.z += rotationSpeedZ * Time.deltaTime;
		myTransform.rotation = Quaternion.Euler (currentRotate.x,currentRotate.y,currentRotate.z);
	
	}
}
