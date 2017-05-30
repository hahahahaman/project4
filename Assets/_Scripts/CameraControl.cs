using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public GameObject player;

	//Vars for camera rotation.
	public float sensitivity = 300f;

	//Vars for camera initialize.
	Vector3 lookAtDirection;
	Quaternion rotation;
	LayerMask mask;
	Vector3 cameraIdealPosition;
	public float distancez = 1f;
	public float distancey = 10f;
	private float currentX = 0f;
	private float currentY = 0f;

	void GetMouseAxis() {
		currentX += Mathf.Clamp(Input.GetAxisRaw ("Mouse X"), -1, 1) * sensitivity * Time.deltaTime;
		currentY += Mathf.Clamp (Input.GetAxisRaw ("Mouse Y"), -1, 1) * sensitivity * Time.deltaTime;

		currentY = Mathf.Clamp (currentY, 0, 130);
		//Debug.Log("X: " + currentX + " Y: " + currentY);
	}

	void RotateCamera() {
		rotation = Quaternion.Euler (-currentY, currentX, 0);
		//RaycastHit hit = new RaycastHit ();

		//if (Physics.Raycast (cameraDefault.position + cameraDefault.TransformDirection (Vector3.back) * 4, cameraDefault.TransformDirection (Vector3.forward), out hit, Vector3.Distance (cameraDefault.position, player.transform.position) - 1)) {
			//transform.position = Vector3.MoveTowards (transform.position, hit.distance, 100 * Time.deltaTime);
			//Debug.Log ("hit"); 
			//Debug.Log (cameraDefault.TransformDirection (Vector3.forward));
		//}
			//transform.position = transform.TransformDirection (Vector3.forward) * (hit.distance * 1.3f);
		//} else {
		//transform.position = Vector3.MoveTowards (transform.position, player.transform.position + rotation * lookAtDirection, 100 * Time.deltaTime);
		//}
		cameraIdealPosition = player.transform.position + rotation * lookAtDirection;
		float unobstructed;
		RaycastHit hit;
		if (Physics.Linecast(player.transform.position, cameraIdealPosition, out hit, mask.value)) {
			unobstructed = -hit.distance + .01f;
		}
		
		transform.position = player.transform.position + rotation * lookAtDirection;
		transform.LookAt (player.transform.position);


	}

	void Start () {
		//cameraDefault = transform;
		mask = 1 << LayerMask.NameToLayer("Clippable");
	}

	void Update() {
		GetMouseAxis();
		lookAtDirection = new Vector3 (0, distancey, -distancez); //max distance between player and camera
		//cameraDefault.position = player.transform.position + rotation * lookAtDirection;
	}

	void LateUpdate () {
		RotateCamera();
	}
}

