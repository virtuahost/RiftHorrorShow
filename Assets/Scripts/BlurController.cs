using UnityEngine;
using System.Collections;

public class BlurController : MonoBehaviour {
	
	public float minBlur;
	public float maxBlur;
	public float sanity;
	public float sanityThreshold;
	public float blurRate;
	public float baseBlurTime;
	public float currBlurTime;
	public GameObject heartBeat;
	
	private float finalBlur;
	private Blur blur;
	private bool blurUp = true;
	private float lastBlurTime;
	private AudioSource heartBeatSound;
	
	// Use this for initialization
	void Start () {
		blur=gameObject.GetComponent<Blur>();
		lastBlurTime = Time.time;
		heartBeatSound = heartBeat.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(sanity < sanityThreshold){
			float currBlurRate = blurRate;
			currBlurTime = baseBlurTime * sanity;
			if(Time.time - lastBlurTime > currBlurTime )
			{	
				
				if(blurUp)
				{
					blur.blurSize+=(maxBlur - minBlur) * currBlurRate * Time.deltaTime;
					if(!heartBeatSound.isPlaying)
						heartBeatSound.Play();
				}
				else
				{
					blur.blurSize-=(maxBlur - minBlur) * currBlurRate * Time.deltaTime;
				}
				if(blur.blurSize > maxBlur)	blurUp =false;
				if(blur.blurSize < minBlur) {
					blurUp = true;
					lastBlurTime = Time.time;
					if(heartBeatSound.isPlaying)
						heartBeatSound.Stop();
				}
			}
			
		}else{
			blur.blurSize = minBlur;
		}
	}
}
