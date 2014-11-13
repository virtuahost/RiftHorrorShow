using UnityEngine;
using System.Collections;

public class SanitySetterScript : MonoBehaviour {
	
	public GameObject c;
	public float sanity=100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		c.GetComponent<ScaryCorridorBehaviour>().setSanity(sanity);
	}
}
