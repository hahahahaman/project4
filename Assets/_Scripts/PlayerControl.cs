using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour {

	public float speed, jump;
	public Camera camera;

	private Rigidbody rb;

	private GameObject pickups;
	private bool isJumping = false;


	void Start(){
		rb = GetComponent<Rigidbody>();
	}

	void Update(){
		int i = 0;
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis( "Horizontal" );
		float moveVertical = Input.GetAxis( "Vertical" );

		Vector3 movement = new Vector3(moveHorizontal*speed, rb.velocity.y, moveVertical*speed);



		movement = Quaternion.Euler(0, camera.transform.eulerAngles.y, 0) * movement;

		rb.velocity = movement;

		if(moveHorizontal == 0 && moveVertical == 0)
			rb.velocity = new Vector3(0f, rb.velocity.y, 0f);

		if(Input.GetButtonDown("Jump") && !isJumping){
			rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);

			isJumping = true;
		}
	}

	void OnCollisionEnter(Collision collision){
		isJumping = false;
	}
}
