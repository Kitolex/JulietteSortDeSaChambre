﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ObjetInteractifs {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	override
	public void Activation()
	{
		this.supprimerObjet ();
	}
}