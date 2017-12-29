using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

	public float vidaMax = 100;
	public float vida = 100;
	public float Daño = 10;


	
	public void SetVida(float cantidad){

		vida += cantidad;
		if(vida>= vidaMax){
			vida = vidaMax;
		}
		if(vida<=0){
		//game over
		}
	}


}
