using UnityEngine;
using System.Collections;

public class PumpkinFloat : MonoBehaviour {
	public float speed = 0.1f;
	public float SecondsUntilDestroy  = 10.0f;
	public Transform player;
	private float startTime = 0f;
	private NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		//startTime = Time.time; 
		//this.transform.position = new Vector3 (player.transform.position.x+10,1.7f,player.transform.position.z+10);
		//this.transform.rotation = player.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.position += speed * this.transform.position;
		Vector3 newVector = new Vector3 (player.position.x, 1.7f, player.position.z);
		agent.SetDestination (newVector);
		//float dist=(player.position - transform.position).magnitude;
		if (Time.time - startTime >= SecondsUntilDestroy) {
			//this.gameObject.SetActive(false);
				}
	}
	void OnCollisionEnter(Collision objColl){
		//this.gameObject.SetActive(false);
	}	
}
