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
	private float finalBlur;
	private Blur blur;
	private bool blurUp = true;
	private float lastBlurTime;
	
	// Use this for initialization
	void Start () {
		blur=gameObject.GetComponent<Blur>();
		lastBlurTime = Time.time;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(sanity < sanityThreshold){
			float currBlurRate = blurRate;
			currBlurTime = baseBlurTime * sanity;
			if(Time.time - lastBlurTime > currBlurTime )
			{
				if(blurUp)
					blur.blurSize+=(maxBlur - minBlur) * currBlurRate * Time.deltaTime;
				else
					blur.blurSize-=(maxBlur - minBlur) * currBlurRate * Time.deltaTime;
				if(blur.blurSize > maxBlur)	blurUp =false;
				if(blur.blurSize < minBlur) {
					blurUp = true;
					lastBlurTime = Time.time;
				}
			}
			
		}else{
			blur.blurSize = minBlur;
		}
	}
}
