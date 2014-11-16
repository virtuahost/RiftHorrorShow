using UnityEngine;
using System.Collections;

public class LightSwitch : MonoBehaviour {

	public Light mMLight;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnPreCull ()
	{
		mMLight.enabled = true;
	}

	void OnPostRender ()
	{
		mMLight.enabled = false;
	}

}
