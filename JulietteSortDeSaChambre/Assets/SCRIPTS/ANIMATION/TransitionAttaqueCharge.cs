﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionAttaqueCharge : StateMachineBehaviour {

	private PrincesseArme princesseArme;

	private PrincesseDeplacement deplacement;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		princesseArme = GameObject.FindGameObjectWithTag("Player").GetComponent<PrincesseArme>();
		deplacement = GameObject.FindGameObjectWithTag("Player").GetComponent<PrincesseDeplacement>();
		//Debug.Log(princesseArme.armeActive);
		Debug.Log("Je passe ici");
		deplacement.vitesse = 0f;
		princesseArme.getHandArme().GetComponent<BoxCollider>().enabled = false;
		
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		princesseArme.getHandArme().GetComponent<BoxCollider>().enabled = true;
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}