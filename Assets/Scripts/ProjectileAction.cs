﻿using UnityEngine;
using System.Collections;

public class ProjectileAction : MonoBehaviour {
	public float damageVal = 5.0f;
	private Transform player;
	private SanitySetterScript sanity;
	public GameObject leftCam;
	public GameObject rightCam;
	
	
	private BlurController leftBlur;
	private BlurController rightBlur;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("player").transform;
		sanity = GameObject.Find ("sanitySetter").GetComponent<SanitySetterScript> ();
		leftBlur = GameObject.Find("CameraLeft").GetComponent<BlurController>();
		rightBlur = GameObject.Find("CameraRight").GetComponent<BlurController>();
		//Debug.Log (this.rigidbody.constantForce);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (this.rigidbody.constantForce);
	}
	void OnTriggerEnter(Collider objColl){
		if (objColl.tag == "player") {
			//Debug.Log("Crash");
			sanity.sanity-=damageVal;
			Destroy (this.gameObject);	
			leftBlur.oneShotPulse();
			rightBlur.oneShotPulse();		
		}
		//Debug.Log("caled");
	
	}
}
