using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public GameObject player;

	//Vars for camera rotation.
	public float sensitivity = 300f;

	//Vars for camera initialize.
	Vector3 lookAtDirection;
	Quaternion rotation;
	private float distance = 3.5f;
	private float currentX = 0f;
	private float currentY = 0f;


	void GetMouseAxis() {
		currentX += Mathf.Clamp(Input.GetAxisRaw ("Mouse X"), -1, 1) * sensitivity * Time.deltaTime;
		currentY += Mathf.Clamp (Input.GetAxisRaw ("Mouse Y"), -1, 1) * sensitivity * Time.deltaTime;

		currentY = Mathf.Clamp (currentY, -60, 60);
		Debug.Log("X: " + currentX + " Y: " + currentY);
	}

	void RotateCamera() {
		rotation = Quaternion.Euler (-currentY, currentX, 0);
		transform.position = player.transform.position + rotation * lookAtDirection;
		transform.LookAt (player.transform.position);
	}

	void Start () {
		lookAtDirection = new Vector3 (0, 0, -distance); //max distance between player and camera
	}

	void Update() {
		GetMouseAxis();
	}

	void LateUpdate () {
		RotateCamera();
	}
		
}

