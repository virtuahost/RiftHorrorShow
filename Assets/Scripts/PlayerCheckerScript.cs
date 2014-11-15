using UnityEngine;
using System.Collections;

public class PlayerCheckerScript : MonoBehaviour {

	public bool isPlayerInside=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "player"){
			isPlayerInside=true;
		}
	}
	
	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "player"){
			isPlayerInside=false;
		}
	}
}
