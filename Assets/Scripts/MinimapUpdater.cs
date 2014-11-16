using UnityEngine;
using System.Collections;

public class MinimapUpdater : MonoBehaviour {
	public Transform playerPosition;
	public GameObject MinimapCamera;
	// Update is called once per frame
	void LateUpdate () {
		//transform.position = new Vector3 (playerPosition.position.x, playerPosition.position.y, playerPosition.position.z);
		MinimapCamera.transform.position = new Vector3 (playerPosition.position.x + 20.0f, playerPosition.position.y, playerPosition.position.z + 20.0f);

	}
}
