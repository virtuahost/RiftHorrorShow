using UnityEngine;
using System.Collections;

public class ScaryCorridorBehaviour : MonoBehaviour {

	public float maxSanity = 100.0f;
	public float minSanity = 0.0f;
	public float wallSpeed;
	public GameObject roomTrigger;
	
	private float currentSanity = 100.0f;
	private Transform leftWall;
	private Transform rightWall;
	private Transform soundRoom;
	private ParticleSystem leftWallParticles;
	private TBE_3DCore.TBE_Source leftWallAudio;
	private TBE_3DCore.TBE_Source rightWallAudio;
	private ParticleSystem rightWallParticles;
	private float initWallSeperation;
	private bool isRunning = false;
	private bool stopRunning=false;
	private bool playSound=false;
	private float soundPlayStart;
	// Use this for initialization
	void Start () {
		leftWall=transform.FindChild("leftWall");
		rightWall=transform.FindChild("rightWall");
		soundRoom=transform.FindChild("soundRoom");
		roomTrigger=soundRoom.FindChild("playerTrigger").gameObject;
		initWallSeperation=rightWall.localPosition.x - leftWall.localPosition.x;
		leftWallParticles=leftWall.FindChild("leftWallEmitter").particleSystem;
		rightWallParticles=rightWall.FindChild("rightWallEmitter").particleSystem;
		leftWallAudio=leftWall.FindChild("leftWallAudio").GetComponent<TBE_3DCore.TBE_Source>();
		rightWallAudio=rightWall.FindChild("rightWallAudio").GetComponent<TBE_3DCore.TBE_Source>();
		leftWallParticles.Stop();
		rightWallParticles.Stop();
		
	
	}
	
	// Update is called once per frame
	void Update () {
	bool playerEntered=roomTrigger.GetComponent<PlayerCheckerScript>().isPlayerInside;
		if(playerEntered)
		{
			if(playSound){
				soundPlayStart=Time.time;
				if(!leftWallParticles.isPlaying){
					leftWallParticles.Play();
				}
				if(!rightWallParticles.isPlaying){
					rightWallParticles.Play();
				}
				if(!leftWallAudio.isPlaying){
					leftWallAudio.Play();
				}
				if(!rightWallAudio.isPlaying){
					rightWallAudio.Play();
				}
			}else{
				if(Time.time - soundPlayStart > 1)
				{
					if(leftWallParticles.isPlaying){
						leftWallParticles.Stop();
					}
					if(rightWallParticles.isPlaying){
						rightWallParticles.Stop();
					}
					if(leftWallAudio.isPlaying){
						leftWallAudio.Stop();
					}
					if(rightWallAudio.isPlaying){
						rightWallAudio.Stop();
					}
				}
			}
		}
	
	}
	
//	public void setSanity(float sanity){
//		if(sanity!=currentSanity){
//			if(!leftWallParticles.isPlaying){
//				leftWallParticles.Play();
//			}
//			if(!rightWallParticles.isPlaying){
//				rightWallParticles.Play();
//			}
//			if(!leftWallAudio.isPlaying){
//				leftWallAudio.Play();
//			}
//			if(!rightWallAudio.isPlaying){
//				rightWallAudio.Play();
//			}
//		}else{
//			if(leftWallParticles.isPlaying){
//				leftWallParticles.Stop();
//			}
//			if(rightWallParticles.isPlaying){
//				rightWallParticles.Stop();
//			}
//			if(leftWallAudio.isPlaying){
//				leftWallAudio.Stop();
//			}
//			if(rightWallAudio.isPlaying){
//				rightWallAudio.Stop();
//			}
//		}
//		currentSanity=sanity;
//	}
//	
//	void setWallSeperation(float seperation){
//		leftWall.localPosition = new Vector3(-seperation/2, 0, 0);
//		rightWall.localPosition = new Vector3(seperation/2, 0, 0);
//		soundRoom.localScale = new Vector3(seperation/initWallSeperation, 1, 1);
//	}
	public void setSanity(float sanity){
		bool playerEntered=roomTrigger.GetComponent<PlayerCheckerScript>().isPlayerInside;
		if(playerEntered){
			float seperation=Mathf.Clamp(sanity*initWallSeperation/(maxSanity-minSanity),2,initWallSeperation);		
			Vector3 leftInitial = leftWall.localPosition;
			Vector3 rightInitial = rightWall.localPosition;
			Vector3 leftFinal = new Vector3(-seperation/2, 0, 0);
			//Debug.Log(leftFinal);
			
			Vector3 rightFinal = new Vector3(seperation/2, 0, 0);
			//Debug.Log(rightFinal);
			Vector3 soundInitial = soundRoom.localScale;
			Vector3 soundFinal = new Vector3(seperation/initWallSeperation, 1, 1);
			
		
				if(isRunning){
					stopRunning=true;
	
				}else{
					StartCoroutine(moveWalls(leftInitial, leftFinal, rightInitial, rightFinal));
				}
		}
		
	}
	
	IEnumerator moveWalls(Vector3 leftInitial, Vector3 leftFinal, Vector3 rightInitial, Vector3 rightFinal){

		isRunning=true;
		playSound=true;
		while(leftWall.localPosition != leftFinal && rightWall.localPosition !=rightFinal){
			if(stopRunning){
				stopRunning = false;
				isRunning = false;
				yield break;
			}
			leftWall.localPosition = Vector3.MoveTowards(leftWall.localPosition, leftFinal, wallSpeed*Time.deltaTime);
			rightWall.localPosition = Vector3.MoveTowards(rightWall.localPosition, rightFinal, wallSpeed*Time.deltaTime);
			Debug.Log(leftWall.localPosition +" "+ rightWall.localPosition);
			soundRoom.localScale = new Vector3((rightWall.localPosition.x - leftWall.localPosition.x)/initWallSeperation , 1, 1);
			yield return new WaitForSeconds(0.01f);	
		}
		isRunning=false;
		playSound=false;
	}
}
