using UnityEngine;
using System.Collections;

public class MinimapUpdater : MonoBehaviour {
	public Transform playerPosition;
	public GameObject rightCamera;
	// Update is called once per frame
	void LateUpdate () {
		//transform.position = new Vector3 (playerPosition.position.x, playerPosition.position.y, playerPosition.position.z);
		//rightCamera.transform.position = new Vector3 (playerPosition.position.x, playerPosition.position.y, playerPosition.position.z);
	}
}
