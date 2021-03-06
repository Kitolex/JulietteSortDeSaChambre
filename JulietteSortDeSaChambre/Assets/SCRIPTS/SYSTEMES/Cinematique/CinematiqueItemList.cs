﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematiqueItemList : ScriptableObject {

	public List<CinematiqueItem> itemList;
	public int item;
	public bool isPassable;
	public bool desactiveBandeNoir;
	public bool desactiveRetourCamera;
	public bool desactiveCoupureSon;


	private Coroutine actualCinematique;


	public void lancer(){
//		Debug.Log("LANCER : "+(item));
		if (itemList [item].isShaking) {
			GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<camera> ().activeShaking ();
			GameControl.control.StartCoroutine (timerShaking ());
			if(itemList [item].son!=null){
				GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ().playOneShot (itemList [item].son);
			}
		} else {
			itemList[item].start ();
			actualCinematique = GameControl.control.StartCoroutine (timer ());
		}

	}

	IEnumerator timerShaking(){

		//	Debug.Log ("test");
		for(var i=0;i<1;i++){
			//	Debug.Log("DUREE ACCES : "+itemList [item].dureeAcces);

			yield return new WaitWhile (() => GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<camera> ().shakingIsActive);
			cinematiqueSuivant ();

		}
		//	Debug.Log ("test2");
	
	}

	IEnumerator timer(){

	//	Debug.Log ("test");
		for(var i=0;i<1;i++){
		//	Debug.Log("DUREE ACCES : "+itemList [item].dureeAcces);
			if(itemList[item].dureeAcces!=0){
				yield return new WaitWhile (() => itemList [item].isInDeplacement);
			}

			if(itemList[item].dureeArret!=0){
		//		Debug.Log ("CinemtiqueDebutTImerArret");
				yield return new WaitForSeconds(itemList[item].dureeArret);
		//		Debug.Log ("CinemtiqueDebutTImerArret");
			}

			cinematiqueSuivant ();



		}
	//	Debug.Log ("test2");



	}

	private void cinematiqueSuivant(){
		GameObject.FindGameObjectWithTag ("HUDAffichageCinematique").GetComponent<AffichageCinematique> ().desactiveText ();
		if (item < itemList.Count - 1) {
			item++;
			lancer ();
		} else {
			if (!desactiveRetourCamera) {
				GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CinematiqueManager> ().ActiveCinematique (false);
			} else {
				GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CinematiqueManager> ().pause=true;
			}

		}
	}

	public void stopCinematique(){
		GameObject.FindGameObjectWithTag ("HUDAffichageCinematique").GetComponent<AffichageCinematique> ().desactiveText ();
		GameControl.control.StopCoroutine (actualCinematique);
		itemList [item].stop ();
	}
}

