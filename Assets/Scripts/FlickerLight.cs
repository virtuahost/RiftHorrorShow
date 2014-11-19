using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Light))]
public class FlickerLight : MonoBehaviour {

	// Average Flicker Rate
	[Range(5,200)]
	public float flickerRate;

	// Random Range (Percentage of flickerRate)
	[Range(0,100)]
	public float randomness;

	// Controllable from the light control
	public bool controllable;

	void Awake(){
		if(controllable)
			gameObject.tag = "Controllable";
	}

	void Start(){
		StartCoroutine (flicker());
	}

	private IEnumerator flicker() {
		float delay = 1.0f / flickerRate;
		light.enabled = true;
		yield return new WaitForSeconds (Random.Range (delay - delay*(randomness/100.0f),delay + delay*(randomness/100.0f)));
		light.enabled = false;
		yield return new WaitForSeconds (Random.Range (delay - delay*(randomness/100.0f),delay + delay*(randomness/100.0f)));
		StartCoroutine (flicker ());
	}

}