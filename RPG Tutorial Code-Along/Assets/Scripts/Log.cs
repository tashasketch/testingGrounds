using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy {

	private Rigidbody2D myRigidBody;
	public Transform target;
	public float chaseRadius;
	public float attackRadius;
	public Transform homePosition;
	public Animator anim;

	// Use this for initialization
	void Start () {
		currentState = EnemyState.idle;
		myRigidBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		target = GameObject.FindWithTag ("Player").transform;

	}
	
	// FixedUpdate is called by physics.
	void FixedUpdate () {
		CheckDistance ();
	}

	//Log finds and walks towards Player.
	void CheckDistance(){
		if (Vector3.Distance (target.position, transform.position) <= chaseRadius
		    && Vector3.Distance (target.position, transform.position) > attackRadius
		    && currentState != EnemyState.stagger) {
			Vector3 temp = Vector3.MoveTowards (transform.position, 
				                target.position, moveSpeed * Time.deltaTime);
			myRigidBody.MovePosition (temp);
			ChangeState (EnemyState.walk);
		} 
	}

	private void ChangeState(EnemyState newState){
		if (currentState != newState) 
		{
			currentState = newState;
		
		}
	}
}
