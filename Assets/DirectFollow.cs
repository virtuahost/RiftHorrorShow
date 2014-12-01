using UnityEngine;
using System.Collections;

public class DirectFollow : MonoBehaviour {

	// Movement Speed
	public float moveSpeed;

	// Player's transform to follow
	public Transform player;

	// Audio Object for pumpkin laughing
	public GameObject laughAudio;

	// Game Controller
	public GameController game;
	
	//Sanity Setter
	public GameObject sanitySetter;
	
	private BlurController leftBlur;
	private BlurController rightBlur;
	
	// Use this for initialization
	void Start () {
		animation.Play ("Shake");
		laughAudio.audio.Play ();
		leftBlur = GameObject.Find("CameraLeft").GetComponent<BlurController>();
		rightBlur = GameObject.Find("CameraRight").GetComponent<BlurController>();
	}
	
	// Update is called once per frame
	void Update () {

		if(game.isRunning()){
			Vector3 dir = (player.position - transform.position).normalized;
			Vector3 newPos = transform.position + dir * moveSpeed * Time.deltaTime;
			newPos.y = 1.0f;
			transform.position = newPos;
			transform.LookAt(player);
		}

	}

	void LateUpdate() {

		if (game.isRunning ()) {
		}

	}
	
	void OnTriggerEnter(Collider c){
	Debug.Log(c.gameObject.name);
		if(c.gameObject.tag == "player"){
			sanitySetter.GetComponent<SanitySetterScript>().sanity-=20;
			leftBlur.oneShotPulse();
			rightBlur.oneShotPulse();
			Destroy(this.gameObject);		
		}
	}


}
