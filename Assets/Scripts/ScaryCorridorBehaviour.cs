using UnityEngine;
using System.Collections;

public class ScaryCorridorBehaviour : MonoBehaviour {

	public float maxSanity = 100.0f;
	public float minSanity = 0.0f;
	
	private float currentSanity = 100.0f;
	private Transform leftWall;
	private Transform rightWall;
	private Transform soundRoom;
	private ParticleSystem leftWallParticles;
	private TBE_3DCore.TBE_Source leftWallAudio;
	private TBE_3DCore.TBE_Source rightWallAudio;
	private ParticleSystem rightWallParticles;
	private float initWallSeperation;
	// Use this for initialization
	void Start () {
		leftWall=transform.FindChild("leftWall");
		rightWall=transform.FindChild("rightWall");
		soundRoom=transform.FindChild("TBE_Room");
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
		float currentWallSeperation=Mathf.Clamp(currentSanity*initWallSeperation/(maxSanity-minSanity),2,initWallSeperation);
		setWallSeperation(currentWallSeperation);
		Debug.Log(currentWallSeperation);
	
	}
	
	public void setSanity(float sanity){
		if(sanity!=currentSanity){
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
		currentSanity=sanity;
	}
	
	void setWallSeperation(float seperation){
		transform.localScale = new Vector3(seperation/initWallSeperation, 1, 1);
	}
}
