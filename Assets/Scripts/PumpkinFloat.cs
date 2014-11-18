using UnityEngine;
using System.Collections;

public class PumpkinFloat : MonoBehaviour {
	public float speed = 0.1f;
	public float SecondsUntilDestroy  = 30.0f;
	public Transform player;
	public GameObject laughAudio;
	public float sanity = 1.0f;
	private float startTime = 0f;
	private NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		startTime = Time.time; 
		laughAudio.audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.position += speed * this.transform.position;
		Vector3 newVector = new Vector3 (player.position.x, this.transform.position.y, player.position.z);
		agent.velocity = agent.velocity * sanity;
		agent.SetDestination (newVector);
		//float dist=(player.position - transform.position).magnitude;
		//this.audio.volume=1.0f/dist;
		//this.audio.Play();
		//float dist=(player.position - transform.position).magnitude;
		if (Time.time - startTime >= SecondsUntilDestroy) {
			laughAudio.audio.Stop ();
			Destroy (this.gameObject);
				}
	}
	void OnTriggerEnter(Collider objColl){
		if (objColl.tag == "player") {
						Destroy (this.gameObject);
				}
	}	
}
