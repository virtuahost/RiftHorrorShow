using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	// Speed/Acc settings
	public float maxSpeed;
	public float sprintSpeed;
	public float acceleration;
	public float deceleration;
	public float gravity;

	// Mouse Sensitivity
	[Range(0,10)]
	public float mouseSensitivity;

	// strafe acceleration
	private float horizontalAcceleration;

	// Usable maxspeed variable (changes depending on sprint)
	private float currentMaxSpeed;
	
	// Player Forward Direction
	public Transform forwardTransform;

	// Camera Controller transform and script
	public Transform cameraControllerTransform;
	public OVRCameraController cameraController;

	// Character Controller
	public CharacterController controller;

	// Flashlight
	public Light flashLight;

	// Flag for first initialization
	private bool initialized = false;

	// Sanity Script
	private SanitySetterScript sanity;

	// Movement/Animation values
	private Vector3 nextMovement;
	private Vector3 prevLocation;
	private float nextRot;
	private float prevRot;

	// Reference to game controller
	private GameController game;
	
	// Use this for initialization
	void Start () {
		horizontalAcceleration = 10;
		prevLocation = transform.position;
		sanity = GameObject.Find ("sanitySetter").GetComponent<SanitySetterScript> ();
		game = GameObject.Find ("GameController").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!initialized) {
			initialized = true;
			OVRCamera.ResetCameraPositionOrientation(Vector3.one, Vector3.zero, Vector3.up, Vector3.zero);
		}

		if (Input.GetButtonDown ("Flashlight")) {
			flashLight.enabled = !flashLight.enabled;
		}
	}
	
	// Physics Update
	void FixedUpdate() {
		if (game.isRunning()) {
			calculateMovement ();
			movePlayer ();
			//Before Mecanim
			animatePlayerEarly ();
		}
		
	}
	
	// Final Update called
	void LateUpdate() {
		//After Mecanim
		animatePlayerLate();
	}
	
	// Calculate the next movement with physics simulation
	private void calculateMovement(){

		// Set max speed based on sprint key
		if(Input.GetButton ("Sprint"))
			currentMaxSpeed = sprintSpeed;
		else
			currentMaxSpeed = maxSpeed;

		// Set current player velocity (vertical movement handled seperately)
		nextMovement = controller.velocity;
		nextMovement.y = 0.0f;

		// Flags for movement
		bool moveV = false, moveH = false;

		// Forward/Backward Movement
		if (Input.GetButton ("Vertical")) {
			moveV = true;
			nextMovement += Input.GetAxis("Vertical") * forwardTransform.forward.normalized * acceleration * Time.deltaTime;
		}

		// Strafing
		if (Input.GetButton ("Horizontal")) {
			moveH = true;
			nextMovement += Input.GetAxis("Horizontal") * forwardTransform.right.normalized * horizontalAcceleration * Time.deltaTime;
		}

		// Mouse Rotation
		prevRot = nextRot;
		nextRot = Input.GetAxis ("Mouse X") * mouseSensitivity;

		// Deceleration
		if (!moveV && !moveH) {
			if(controller.velocity.magnitude < .5f)
				nextMovement = Vector3.zero;
			else
				nextMovement -= controller.velocity.normalized * deceleration * Time.deltaTime;
		}

		// Keep Movement under max speed
		if(nextMovement.magnitude > currentMaxSpeed){
			nextMovement *= (currentMaxSpeed/nextMovement.magnitude);
		}

	}
	
	// Apply gravity and attempt movement with the player controller
	private void movePlayer(){
		nextMovement.y = controller.velocity.y - gravity * Time.deltaTime;
		prevLocation = transform.position;
		controller.Move (nextMovement * Time.deltaTime);
		transform.Rotate (0, nextRot, 0, Space.World);
	}
	
	// Before Mecanim
	private void animatePlayerEarly(){
		
	}
	
	// After Mecanim
	private void animatePlayerLate(){
		
	}

	// Triggers
	void OnTriggerEnter(Collider trigger){

		// Alpha Sanity Checkpoints
		if (trigger.tag == "SanityCheckpoint") {
			SanityCheckpoint cp = trigger.GetComponent<SanityCheckpoint>();
			if(sanity != null && cp != null){
				sanity.sanity = cp.sanity;
			}
		}

	}
	
}
