using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public GameObject player;

	//Vars for camera rotation speed.
	public float rotationSpeed = 70;

	// Vars for camera transform.
	private Vector3 offset = new Vector3(0, 2.5f, -3.5f);
	private Quaternion rotationOffset = Quaternion.identity;

	void InitiateCameraTransform() {
		rotationOffset.eulerAngles = new Vector3(25, 0, 0);
		transform.position = player.transform.position + offset;
		transform.rotation = rotationOffset;
	}



	void RotateCamera() {
		if (Input.GetAxis ("Mouse X") > 0) {
			transform.RotateAround (player.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
		} else if (Input.GetAxis ("Mouse X") < 0) {
			transform.RotateAround (player.transform.position, Vector3.down, rotationSpeed * Time.deltaTime);
		} else if (Input.GetAxis ("Mouse Y") > 0) {
			transform.RotateAround (player.transform.position, Vector3.right, rotationSpeed * Time.deltaTime);
		} else if (Input.GetAxis ("Mouse Y") < 0) {
			transform.RotateAround (player.transform.position, Vector3.left, rotationSpeed * Time.deltaTime);
		}	
	}

	void Start () {
		InitiateCameraTransform ();
	}
		
	void LateUpdate () {
		RotateCamera ();
		//transform.position = player.transform.position + offset;
		//
	}
		
}

