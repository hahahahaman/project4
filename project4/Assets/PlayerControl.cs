using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour {

	public float speed, jump;

	private Rigidbody rb;

	private GameObject pickups;


	void Start(){
		rb = GetComponent<Rigidbody>();
	}

	void Update(){
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis( "Horizontal" );
		float moveVertical = Input.GetAxis( "Vertical" );

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);

		/*if(!Input.GetKey("Horizontal") && !Input.GetKey("Vertical")){
			rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
		}*/
		if(moveHorizontal == 0 && moveVertical == 0)
			rb.velocity = new Vector3(0f, rb.velocity.y, 0f);

		if(Input.GetButtonDown("Jump") && transform.position.y == 1f){
			rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
			//rb.AddForce( new Vector3(0.0f, jumpForce, 0.0f), ForceMode.Impulse);
		}
	}
}
