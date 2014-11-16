using UnityEngine;
using System.Collections;

public class MapToggle : MonoBehaviour {
	public GameObject CameraRight;
	public GameObject CameraLeft;
	public GameObject OrgCameraRight;
	public GameObject OrgCameraLeft;
	public GameObject DirectionalLight;
	private bool mapMode = false;
	// Update is called once per frame
	void Start(){		
		CameraRight.camera.enabled = mapMode;
		CameraLeft.camera.enabled = mapMode;
		DirectionalLight.light.enabled = mapMode;
		
		OrgCameraRight.camera.enabled = !mapMode;
		OrgCameraLeft.camera.enabled = !mapMode;
		}

	void Update () {
		if (Input.GetKeyUp(KeyCode.M)){
			mapMode = !mapMode;
			
			CameraRight.camera.enabled = mapMode;
			CameraLeft.camera.enabled = mapMode;
			DirectionalLight.light.enabled = mapMode;
			
			OrgCameraRight.camera.enabled = !mapMode;
			OrgCameraLeft.camera.enabled = !mapMode;
		}	
	}
}
