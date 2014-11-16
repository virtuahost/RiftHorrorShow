using UnityEngine;
using System.Collections;

public class MapToggle : MonoBehaviour {
	public GameObject MinimapQuad;
	public GameObject OrgCameraRight;
	public GameObject OrgCameraLeft;
	public GameObject DirectionalLight;
	private bool mapMode = false;
	// Update is called once per frame
	void Start(){		
		//MinimapCamera.camera.enabled = mapMode;
		//DirectionalLight.light.enabled = mapMode;
		
		//OrgCameraRight.camera.enabled = !mapMode;
		//OrgCameraLeft.camera.enabled = !mapMode;
		}

	void Update () {
		//if (Input.GetKeyUp(KeyCode.M)){
		//	mapMode = !mapMode;
		//	
		//	MinimapCamera.camera.enabled = mapMode;
		//	DirectionalLight.light.enabled = mapMode;
		//	
		//	OrgCameraRight.camera.enabled = !mapMode;
		//	OrgCameraLeft.camera.enabled = !mapMode;
		//}	
	}
}
