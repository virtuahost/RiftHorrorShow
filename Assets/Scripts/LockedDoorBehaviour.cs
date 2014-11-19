using UnityEngine;
using System.Collections;

public class LockedDoorBehaviour : MonoBehaviour {

	public GameObject doorAnimator;
	
	void OnTriggerEnter(Collider c)
	{
		Animator animator=doorAnimator.GetComponent<Animator>();
		if(c.gameObject.tag=="player")
		{
			Vector3 playerDirection=transform.position-c.transform.position;
			float crossY=Vector3.Cross(playerDirection, transform.forward).y;
			if(crossY > 0 )
			{
				animator.SetBool("openClock", true);
			}else{
				animator.SetBool("openAntiClock", true);
			}
		}
	}
	
	void OnTriggerExit(Collider c)
	{
		Animator animator=doorAnimator.GetComponent<Animator>();
		if(c.gameObject.tag=="player")
		{
			Vector3 playerDirection=transform.position-c.transform.position;
			float crossY=Vector3.Cross(playerDirection, transform.forward).y;
			Debug.Log(Vector3.Cross(playerDirection, transform.forward));
			if(crossY > 0)
			{
				animator.SetBool("closeAntiClock", true);
			}else{
				animator.SetBool("closeClock", true);
			}
		}
	}
}
