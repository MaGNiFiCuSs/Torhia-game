//Aplicar a bazico y ajustar pos disparo (hijos o mierdas al arma)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimFlip : MonoBehaviour {

	public GameObject Proyectil;
	public GameObject Gancho;
	public GameObject Personaje;
	public Camera camara;
	public float test;

	private bool facingRight = true;


	void Update () {
		  

		  //Aim, falta por hacer un flip al sprite
		  Vector2 direccion = Camera.main.ScreenToWorldPoint( Input.mousePosition ) - transform.position;
		  Quaternion rotacion = Quaternion.FromToRotation(transform.right, direccion);
		  transform.rotation = rotacion * transform.rotation;

		  
		  if(direccion.x> 0f &&!facingRight && !Gancho.activeSelf)
			Flip();
		else if(direccion.x< 0f && facingRight && !Gancho.activeSelf)
			Flip(); 
		  //dispara
		if(Input.GetMouseButtonDown(1)){
		  	GameObject bala = Instantiate( Proyectil, transform.position, transform.rotation);
		  	bala.GetComponent<Rigidbody2D>().velocity= direccion*7;
		}

		if(Input.GetKeyDown(KeyCode.E)&& !Gancho.activeSelf){
			//GanchoFuncion(direccion);
			/*float distancia;
			bool vuelve = false;
			
			GameObject GanchoG = Instantiate( Gancho, transform.position, transform.rotation);*/
			Gancho.SetActive(true);
			Gancho.GetComponent<Rigidbody2D>().velocity= direccion.normalized*10;
			
			/*distancia = Vector3.Distance(GanchoG.transform.position, Personaje.transform.position);
			
			test=distancia =distancia;
			if(distancia > 30f){
				GanchoG.GetComponent<Rigidbody2D>().velocity= -GanchoG.GetComponent<Rigidbody2D>().velocity;
				vuelve = true;
				Debug.Log("se aleja");
			}
			if(distancia <= 1&& vuelve){
				Destroy(GanchoG);
				Debug.Log("destroy");
			}*/
		}
		  
	}
	
	void Flip(){
		facingRight = !facingRight;
		Vector3 escala = Personaje.transform.localScale;
		escala.x *= -1;
		Personaje.transform.localScale = escala;
	}

	/*void GanchoFuncion(Vector2 direccion){
		float distancia;
		bool vuelve = false;
		
		GameObject GanchoG = Instantiate( Gancho, transform.position, transform.rotation);
		GanchoG.GetComponent<Rigidbody2D>().velocity= direccion.normalized*2;
		
		distancia = Vector2.Distance(GanchoG.transform.position, Personaje.transform.position);

		if(distancia > 30f){
			GanchoG.GetComponent<Rigidbody2D>().velocity= -GanchoG.GetComponent<Rigidbody2D>().velocity;
			vuelve = true;
			Debug.Log("se aleja");
		}
		if(distancia <= 1&& vuelve){
			Destroy(GanchoG);
			Debug.Log("destroy");
		}
		
	}*/
}
