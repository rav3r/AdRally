using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {
	
	public Vector3 direction;
	public float rotationSpeed;
	public float maxVelocity;
	public float engineForce;
	
	void Start () {
	}
	
	
	void Update () {
		// Symulacja silnika
		rigidbody.AddForce(transform.rotation * direction * engineForce * Time.deltaTime);
		
		float currVelocity = rigidbody.velocity.magnitude;
		
		if(currVelocity > maxVelocity) {
			rigidbody.velocity *= maxVelocity / currVelocity;
		}
		
		// Obracanie autem
		transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed);
	}
}
