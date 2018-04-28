using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWeaponRack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public bool Destroy = false;
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.CompareTag ("sword") && col.transform.GetComponentInParent <PlayerMovement>().Chopping) {
			
			Debug.Log ("hit");
			Destroy = true;
			transform.GetChild (0).GetChild (0).GetComponent <ParticleSystem>().Play (false);

		}
	}
}
