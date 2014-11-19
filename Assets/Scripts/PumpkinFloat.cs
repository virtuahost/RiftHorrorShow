using UnityEngine;
using System.Collections;

public class PumpkinFloat : MonoBehaviour {
	public float speed = 0.1f;
	public float SecondsUntilDestroy  = 30.0f;
	public Transform player;
	public GameObject laughAudio;
	public GameObject lightPumpkin;
	public GameObject pumpkin;
	private SanitySetterScript sanity;
	private float startTime = 0f;
	private NavMeshAgent agent;
	public Animation startAnime;
	private bool chaseMode = false; 
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		//startTime = Time.time; 
		//laughAudio.audio.Play ();
		lightPumpkin.light.enabled = false;
		sanity = GameObject.Find ("sanitySetter").GetComponent<SanitySetterScript> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		float angleDelta = 0f;
		
		// check if value not 0 and tease the rotation towards it using angleDelta
		if(this.transform.rotation.x > 0 ){
			angleDelta = -0.2f;
		} else if (this.transform.rotation.x < 0){
			angleDelta = 0.2f;
		}
		//this.transform.position += speed * this.transform.position;
		float dist=(player.position - transform.position).magnitude;		
		if (dist >= 10.0f) {
			chaseMode = false;
			laughAudio.audio.Stop();
		}
		if (sanity.sanity < 80 && sanity.sanity > 60) {
					lightPumpkin.light.enabled = true;
			lightPumpkin.light.intensity = lightPumpkin.light.intensity;
		} else if (sanity.sanity < 60 && sanity.sanity > 40) {
					lightPumpkin.light.enabled = true;
					lightPumpkin.light.intensity = lightPumpkin.light.intensity;
					/*this.transform.position = new Vector3(this.transform.position.x,1.7f / sanity.sanity,this.transform.position.z);
					Quaternion rotaPlay = player.transform.rotation;	
			Quaternion finalRota = new Quaternion(this.transform.rotation.x + angleDelta * 10,rotaPlay.y,rotaPlay.z,rotaPlay.w);
				Quaternion.Slerp(pumpkin.transform.rotation,finalRota,angleDelta);
			//pumpkin.transform.Rotate; += angleDelta; //new Quaternion(this.transform.rotation.x + angleDelta,rotaPlay.y,rotaPlay.z,rotaPlay.w);*/
			this.animation.Play("Shake");
				}
		else if(sanity.sanity <= 40)
		{
			lightPumpkin.light.enabled = true;
			lightPumpkin.light.intensity = lightPumpkin.light.intensity;
			if(dist <= 10.0f)
			{
				this.transform.position = new Vector3(this.transform.position.x,1.7f,this.transform.position.z);
				chaseMode = true;
			}
			if(chaseMode)
			{		
				//laughAudio.audio.volume=1.0f/dist;
				if(!laughAudio.audio.isPlaying)
				{
					laughAudio.audio.Play();	
				}	
				Vector3 newVector = new Vector3 (player.position.x, this.transform.position.y, player.position.z);
				//agent.velocity = agent.velocity * sanity.sanity;
				agent.SetDestination (newVector);
			}
		}
		//float dist=(player.position - transform.position).magnitude;		
		//float dist=(player.position - transform.position).magnitude;
		//if (Time.time - startTime >= SecondsUntilDestroy) {
		//	laughAudio.audio.Stop ();
		//	Destroy (this.gameObject);
		//		}
	}
	void OnTriggerEnter(Collider objColl){
		//if (objColl.tag == "player") {
		//				Destroy (this.gameObject);
		//		}
	}	
}
