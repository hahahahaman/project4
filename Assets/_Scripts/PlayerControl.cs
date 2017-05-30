using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour {

	public float speed, jump, gravity;
	public Camera camera;

	private Rigidbody rb;

	private GameObject pickups;
	private bool isJumping = false;
	private bool isTouchingWall = false, isTouchingGround = false;


	void Start(){
		rb = GetComponent<Rigidbody>();
	}

	void Update(){
		int i = 0;

		RaycastHit hit;

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		Physics.Raycast(ray, out hit);

		Debug.DrawRay(camera.transform.position, camera.transform.forward * 10000f, Color.green, 0.001f);
		Debug.DrawRay(rb.position, (hit.point - rb.position) * 10000f, Color.red, 0.001f);
	}

	void FixedUpdate(){
		/* movement */
		float moveHorizontal = Input.GetAxis( "Horizontal" );
		float moveVertical = Input.GetAxis( "Vertical" );

		Vector3 movement = new Vector3(moveHorizontal*speed, rb.velocity.y, moveVertical*speed);

		movement = Quaternion.Euler(0, camera.transform.eulerAngles.y, 0) * movement;

		rb.velocity = movement;

		if(moveHorizontal == 0 && moveVertical == 0)
			rb.velocity = new Vector3(0f, rb.velocity.y, 0f);

		if(Input.GetButton("Jump") && !isJumping){
			rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);

			isJumping = true;
		}

		/*
		if(!isJumping && Input.GetButton("Fire3")){
			rb.velocity = Vector3.zero;
			Debug.Log("Pressed");
		}
		*/
	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "Ground"){
			isTouchingGround = true;
		}
			
		if(collision.gameObject.tag == "Wall")
			isTouchingWall = true;
		
		isJumping = false;

		//Debug.Log(collision.gameObject.tag);
	}

	void OnCollisionExit(Collision collision){
		if(collision.gameObject.tag == "Ground"){
			isTouchingGround = false;
		}
			
		if(collision.gameObject.tag == "Wall")
			isTouchingWall = false;
	}
}
