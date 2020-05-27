using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    // Used by both octopus and shark (Enemy)

	private PlayerController thePlayer;

	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			thePlayer.hurt ();	 
		}

	}
}
