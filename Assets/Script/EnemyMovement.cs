using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIState
{
	MOVE_LEFT ,
	MOVE_RIGHT
}

public class EnemyMovement : MonoBehaviour {
	public Transform currentDestination;
Rigidbody2D rigid ;
public float Timer;
	public bool isRight;
	public List<Transform> listpoint;
	public bool Chopping;
	public AIState state = AIState.MOVE_LEFT;
	public AIState currentstate {
		
		set{
			state = value;

			if (state == AIState.MOVE_LEFT) {
				isRight = false;
				transform.Rotate (new Vector3(0,180,0));
			}else if (state == AIState.MOVE_RIGHT) {
				isRight = true;
				transform.Rotate (new Vector3(0,180,0)); 
			}
		}
	}
	// Use this for initialization
	void Start () {
		rigid = gameObject.GetComponent<Rigidbody2D>();
        Timer = 0;
		isRight = true;
		Debug.Log (AIState.MOVE_LEFT);
		currentDestination = listpoint[0];
	}
	public bool onGround = true;
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance (currentDestination.position, transform.position)<1.5) {
			isRight = !isRight;
			if (isRight) {
				state = AIState.MOVE_RIGHT;
			}else{
				state = AIState.MOVE_LEFT;
			}
			currentDestination =listpoint[ (listpoint.IndexOf (currentDestination) + 1) % listpoint.Count];
			transform.Rotate (new Vector3(0,180,0));
		}
		MoveCharacter (isRight);

//        Timer += Time.deltaTime;
//		if (Input.GetKeyDown("w") && onGround == true){
//
//			rigid. AddRelativeForce(new Vector2(0,10), ForceMode2D.Impulse);
//			onGround = false;
//		} 
//
//        if (Input.GetKey("s"))
//        {
//			Timer = 0;
//			GetComponent<Collider2D>().enabled = false;
//        }
//		if (Input.GetMouseButtonDown (0)){
//			Debug.Log ("string");
//			transform.GetChild (0).GetComponent <Collider2D>();
//			GetComponent <Animator>().SetTrigger ("Trigger");
//		}
//		//RaycastHit hitInfo;
//        //hitInfo.transform.gameObject.GetComponent<tree>().IAMMElted();
//		if (Timer > 0.5) {
//			GetComponent<Collider2D> ().enabled = true;
//		}
        // GetComponent<Collider2D>().enabled=! Input.GetKey("s"); // true when press down

        //  want to turn off when down
	} 

	void MoveCharacter (bool isRight){
		if (isRight) {
			Debug.Log (rigid);
			rigid.AddRelativeForce(new Vector2(100, 0), ForceMode2D.Force);

		} else {
			
			rigid.AddRelativeForce(new Vector2(-100, 0), ForceMode2D.Force);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("terrain")) {
				onGround = true;
			}

	}
}
