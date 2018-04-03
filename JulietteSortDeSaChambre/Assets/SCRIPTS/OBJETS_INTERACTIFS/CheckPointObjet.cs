﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointObjet : ObjetEnvironnemental {

	private bool active;
	public GameObject book;

	// Use this for initialization
	void Start () {
		active = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Activation ()
	{
		if(!active){
			GetComponent<CheckPoint> ().trigger ();
			book.SetActive (false);
			active = true;
		}

	}

	public override EnumIconeInterraction getIconeInteraction(){
		if (active) {
			return EnumIconeInterraction.icone_null;
		} else {
			return EnumIconeInterraction.icone_default;
		}

	}
}