using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SanitySetterScript : MonoBehaviour {
	
	public List<GameObject> c;
	public float sanity=100;

	public bool flickerControl;
	public float delay;

	private Light[] lights;

	// Use this for initialization
	void Start () {
		findControllableLights ();
		if (flickerControl) {
			StartCoroutine (lightFlicker());
		}
	}
	
	// Update is called once per frame
	void Update () {
	foreach(GameObject corr in c)
		corr.GetComponent<ScaryCorridorBehaviour>().setSanity(sanity);
	}

	private void findControllableLights(){
		List<Light> temp = new List<Light> ();
		Light[] all = (Light[])GameObject.FindObjectsOfType(typeof(Light));
		for (int i = 0; i < all.Length; i++) {
			if(all[i].gameObject.tag == "Controllable"){
				temp.Add (all[i]);
			}
		}
		
		lights = temp.ToArray ();
		
	}

	private IEnumerator lightFlicker(){
		for (int i = 0; i < lights.Length; i++) {
			FlickerLight flicker = lights[i].gameObject.GetComponent<FlickerLight>();
			flicker.flickerRate = 60 - (sanity/100.0f) * 59.67f; //Random.Range (5.0f,200.0f);
			//flicker.randomness = 100.0f - sanity;//Random.Range (0.0f,100.0f);
		}
		yield return new WaitForSeconds (delay);
		if(flickerControl)
			StartCoroutine (lightFlicker());
	}
	
}
