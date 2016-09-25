using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	//Storing the reference to RagePixelSprite -component
	private IRagePixel ragePixel;

	//enum for character state
	public enum WalkingState {Standing=0, WalkRight, WalkLeft, Jump};
	public WalkingState state = WalkingState.Standing;
	
	public float MoveSpeed = 30f;

	private bool SpaceIsGelickt = false;
	private bool Jump = false;
	//private bool Trigger = false;

	private float cd_GattlingCooldown = 0;
	private float cd_Gattling = 0.9f; // cooldown time in seconds

	// Use this for initialization
	void Start () {
		ragePixel = GetComponent<RagePixelSprite>();
	}

	// Update is called once per frame
	void Update () {
		GameObject press = GameObject.Find("press space");
		if (press == null) SpaceIsGelickt = true;
		if (cd_GattlingCooldown > 0) cd_GattlingCooldown -= Time.deltaTime;
		//Check the keyboard state and set the character state accordingly
		if (Input.GetKey (KeyCode.Space) || SpaceIsGelickt) {
			SpaceIsGelickt = true;
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				HandleActionInput();
			}
			else if(Input.GetKeyDown (KeyCode.W)) {
				HandleActionInput();
			}
			else if (Input.GetKey (KeyCode.LeftArrow)) {
				state = WalkingState.WalkLeft;
			}
			else if(Input.GetKey (KeyCode.A)) {
				state = WalkingState.WalkLeft;
			}
			else if (Input.GetKey (KeyCode.RightArrow)) {
				state = WalkingState.WalkRight;
			}
			else if(Input.GetKey (KeyCode.D)) {
				state = WalkingState.WalkRight;
			}
			else {
				state = WalkingState.Standing;
			}
			
			Vector3 moveDirection = new Vector3();
			
			switch (state)
			{
			case(WalkingState.Standing):
				ragePixel.SetHorizontalFlip(false);
				ragePixel.PlayNamedAnimation("STAY", false);
				break;
				
			case (WalkingState.WalkLeft):
				ragePixel.SetHorizontalFlip(true);
				ragePixel.PlayNamedAnimation("WALK", false);
				moveDirection = new Vector3(-1f, 0f, 0f);
				break;
				
			case (WalkingState.WalkRight):
				ragePixel.SetHorizontalFlip(false);
				ragePixel.PlayNamedAnimation("WALK", false);
				moveDirection = new Vector3(1f, 0f, 0f);
				break;
			}

			transform.Translate(moveDirection * Time.deltaTime * MoveSpeed);
		}
	}
	/*
	void OnCollisionEnter2D(Collision2D other) {
		if (other.transform.tag == "GROUND") {
			Debug.Log ("GROUNDED");
			Trigger = true;
		}
	}

	void OnCollisionExit2D(Collision2D other) {
		if (other.transform.tag == "GROUND") {
			Debug.Log ("NOT GROUNDED");
			Trigger = false;
		}
	}
	*/
	void HandleActionInput () { 
		if(cd_GattlingCooldown == 0 || cd_GattlingCooldown < 0){
			cd_GattlingCooldown += cd_Gattling;
			Vector3 moveDirectionJump = new Vector3();
			moveDirectionJump = new Vector3(0f, 2500f, 0f);
			transform.Translate(moveDirectionJump * Time.deltaTime);
		}
	}
}
