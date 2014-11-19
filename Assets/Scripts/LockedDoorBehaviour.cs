using UnityEngine;
using System.Collections;

public class LockedDoorBehaviour : MonoBehaviour {

	public GameObject doorAnimator;
	public GameObject player;
	
	void OnTriggerEnter(Collider c)
	{
		Animator animator=doorAnimator.GetComponent<Animator>();
		Inventory inv=player.GetComponent<Inventory>();
		if(c.gameObject.tag=="player")
		{
			Vector3 playerDirection=transform.position-c.transform.position;
			float crossY=Vector3.Cross(playerDirection, transform.forward).y;
			if(crossY > 0 )
			{
				if(inv.hasItem(0))
				{
					animator.SetBool("openClock", true);
				}
			}else{
				if(inv.hasItem(0))
				{
					animator.SetBool("openAntiClock", true);
				}
			}
		}
	}
	
	void OnTriggerExit(Collider c)
	{
		Animator animator=doorAnimator.GetComponent<Animator>();
		Inventory inv=player.GetComponent<Inventory>();
		if(c.gameObject.tag=="player")
		{
			Vector3 playerDirection=transform.position-c.transform.position;
			float crossY=Vector3.Cross(playerDirection, transform.forward).y;
			Debug.Log(Vector3.Cross(playerDirection, transform.forward));
			if(crossY > 0 )
			{
				if(inv.hasItem(0))
				{
					animator.SetBool("closeAntiClock", true);
				}
			}else{
				if(inv.hasItem(0))
				{
					animator.SetBool("closeClock", true);
				}
			}
		}
	}
}
