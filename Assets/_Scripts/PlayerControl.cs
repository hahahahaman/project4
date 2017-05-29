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
		Debug.DrawRay(camera.transform.position, camera.transform.forward * 10000f, Color.green);
	}

	void FixedUpdate(){
		/* movement */
		float moveHorizontal = Input.GetAxis( "Horizontal" );
		float moveVertical = Input.GetAxis( "Vertical" );

		Vector3 movement = new Vector3(moveHorizontal*speed, rb.velocity.y, moveVertical*speed);
<<<<<<< HEAD

=======
>>>>>>> da2b10e3a082c89a6f7394d1e6299844ce56fa00
		movement = Quaternion.Euler(0, camera.transform.eulerAngles.y, 0) * movement;

		rb.velocity = movement;

		if(moveHorizontal == 0 && moveVertical == 0)
			rb.velocity = new Vector3(0f, rb.velocity.y, 0f);

		if(Input.GetButton("Jump") && !isJumping){
			rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);

			isJumping = true;
		}

		if(!isJumping && Input.GetButton("Fire3")){
			rb.velocity = Vector3.zero;
			Debug.Log("Pressed");
		}
	}

	void OnCollisionEnter(Collision collision){
		isJumping = false;
	}
}
