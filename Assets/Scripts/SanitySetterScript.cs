using UnityEngine;
using System.Collections.Generic;

public class SanitySetterScript : MonoBehaviour {
	
	public List<GameObject> c;
	public float sanity=100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	foreach(GameObject corr in c)
		corr.GetComponent<ScaryCorridorBehaviour>().setSanity(sanity);
	}
	
	
}
