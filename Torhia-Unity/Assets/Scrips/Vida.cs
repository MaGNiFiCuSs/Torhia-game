using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour {

	public GameObject player;
	Stats jugador;
	void Awake(){
		jugador = player.GetComponent<Stats>();
	}
	// Use this for initialization
	void OnCollisionEnter2D(Collision2D collision){
		if( collision.gameObject.CompareTag("Player"))
			jugador.SetVida(10f);

	}
}
