using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Flag for pausing win/lose state etc
	private bool running;

	// Reference for current sanity level
	private SanitySetterScript sanity;

	// PLayer reference
	private GameObject player;
	
	// Use this for initialization
	void Start () {
		running = true;
		sanity = GameObject.Find ("sanitySetter").GetComponent<SanitySetterScript> ();
		player = GameObject.Find ("player");
	}

	// every frame
	void Update(){
		if(sanity.sanity == 0){
			triggerLoss();
		}
	}

	// get running states
	public bool isRunning(){
		return running;
	}

	// set running state
	private void setRunning(bool isRunning){
		this.running = isRunning;
	}

	// pause game
	public void pause(){
		setRunning (false);
	}

	// resume game
	public void play(){
		setRunning (true);
	}

	// when the player's sanity reaches 0
	private void triggerLoss(){
		setRunning (false);
	}

}
