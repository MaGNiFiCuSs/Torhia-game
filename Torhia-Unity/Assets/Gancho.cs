using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gancho : MonoBehaviour {

	public GameObject Player;
	public float distancia;
	public bool vuelve = false;
	public float tiempoVuela=0f;
	public bool once = false;

	void OnEnable(){
		Debug.Log("hola");
		tiempoVuela=0f;
	}
	
	// parent.transform.position += child.transform.forward * Time.deltaTime;
	void FixedUpdate () {
		distancia = Vector2.Distance(this.transform.position, Player.transform.position);
		tiempoVuela +=Time.deltaTime;
		if(distancia > 10f && !vuelve){
			if(!once){
				tiempoVuela=0f;
				once = true;
			}
			gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			transform.position = Vector3.Lerp(transform.position, Player.transform.position, tiempoVuela);
			vuelve = true;
		}
		if(distancia <= 1 && vuelve){
			vuelve = false;
			once = false;
			gameObject.SetActive(false);
		}

	}

}
