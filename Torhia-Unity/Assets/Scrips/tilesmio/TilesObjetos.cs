using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//[ExecuteInEditMode]
//requiere meshes para gameobject

public class TilesObjetos : MonoBehaviour {

	public int altura=1;
	public int longitud=1;
	public bool Izquierda = true;
	public bool Derecha = true;
	public bool Top = true;
	public bool Bot = true;
	public enum TipoSprite {Bosque, cueva, fondo};	
	public TipoSprite tipo;
	public float tamaño;
	public GameObject Tile;
	public GameObject Manejador;
	public bool handler ;
	public bool iniciado;

	//basura handles
	public Vector3 posicion1;


	public Sprite[] TileTopIzq;
	public Sprite[] TileTopMed;
	public Sprite[] TileTopDer;
	public Sprite[] TileMidIzq;
	public Sprite[] TileMidMed;
	public Sprite[] TileMidDer;
	public Sprite[] TileBotIzq;
	public Sprite[] TileBotMed;
	public Sprite[] TileBotDer;	
	
	private SpriteRenderer SR;





	public GameObject Manejador1;
	public GameObject Manejador2;
	public GameObject Manejador3;
	public GameObject Manejador4;

	//on start empieza
	private void Awake () {
		if(!iniciado){
			Generar();
			iniciado = true;
		}
		
	}



	public void Generar() {

		//basura
		longitud += (Izquierda? 1 : 0)+ (Derecha? 1 : 0);
		altura += (Top? 1 : 0)+ (Bot? 1 : 0);
		

		//Handles
		


		//intento2
		for (int y = 0; y < altura; y++) {
			for (int x = 0; x < longitud; x++) {



				/*
				(x <=1 && y <=1 && Top && Izquierda)
				(y <=1 && Top)
				(y <=1 && Top && x >= longitud &&  Derecha)

				(x <=1 && Izquierda)
				(x >= longitud &&  Derecha)

				(y >=altura && Bot && x <=1 && Izquierda )
				(y >=altura && Bot)
				(y >=altura && Bot && x >= longitud &&  Derecha)
				*/
				Vector3 posicion = new Vector3 (transform.position.x + x* tamaño, transform.position.y + y * tamaño, transform.position.z);
				var tile = Instantiate(Tile, posicion, transform.rotation);
				SR = tile.GetComponent<SpriteRenderer>();
				tile.transform.parent = gameObject.transform;

				if ( x > 0 && y > 0 && x < (longitud-1) && y < (altura-1) )
					SR.sprite = TileMidMed[0];

				else if(y == 0 && x == 0){
					if (Bot && Izquierda) 
						SR.sprite = TileBotIzq[0];
					else if(Bot)
						SR.sprite = TileBotMed[0];
					else if(Izquierda)
						SR.sprite = TileMidIzq[0];
					else
						SR.sprite = TileMidMed[0];

				}else if(y == 0 && x < longitud -1){
					if (Bot)
						SR.sprite = TileBotMed[0];
					else
						SR.sprite = TileMidMed[0];

				}else if(y == 0 && x == longitud -1){
					if (Bot && Derecha)
						SR.sprite = TileBotDer[0];
					else if(Bot)
						SR.sprite = TileBotMed[0];
					else if(Derecha)
						SR.sprite = TileMidDer[0];
					else
						SR.sprite = TileMidMed[0];

				}else if(x == longitud -1 && y < altura -1){
					if (Derecha)
						SR.sprite = TileMidDer[0];
					else
						SR.sprite = TileMidMed[0];

				}else if(x == longitud -1 && y == altura -1){
					if (Derecha && Top)
						SR.sprite = TileTopDer[0];
					else if (Derecha)
						SR.sprite = TileMidDer[0];
					else if (Top) 
						SR.sprite = TileTopMed[0];
					else
						SR.sprite = TileMidMed[0];

				}else if(y == altura -1 && x > 0){
					if (Top)
						SR.sprite = TileTopMed[0];
					else
						SR.sprite = TileMidMed[0];

				}else if(y == altura -1 && x == 0){
					if (Izquierda && Top)
						SR.sprite = TileTopIzq[0];
					else if (Izquierda)
						SR.sprite = TileMidIzq[0];
					else if (Top)
						SR.sprite = TileTopMed[0];
					else
						SR.sprite = TileMidMed[0];
					
				}else if(x == 0 && y > 0){
					if (Izquierda)
						SR.sprite = TileMidIzq[0];
					else
						SR.sprite = TileMidMed[0];
				}
			}
		}
	}  

	

	void  OnDrawGizmosSelected(){
		
		if(!handler){
			Manejador1 = Instantiate(Manejador, transform.position + new Vector3(-tamaño/2, -tamaño/2, 0f), transform.rotation);
			Manejador1.transform.parent = gameObject.transform;	

			Manejador2 = Instantiate(Manejador, transform.position + new Vector3(longitud -tamaño/2, -tamaño/2, 0f),transform.rotation);
			Manejador2.transform.parent = gameObject.transform;	
			Manejador3 = Instantiate(Manejador, transform.position + new Vector3(-tamaño/2, altura-tamaño/2, 0f), transform.rotation);
			Manejador3.transform.parent = gameObject.transform;	
			Manejador4 = Instantiate(Manejador, transform.position + new Vector3( longitud -tamaño/2, altura -tamaño/2, 0f),transform.rotation);
			Manejador4.transform.parent = gameObject.transform;	

			handler = true;
			Debug.Log("funca2");
		}
		
		
	}
	private void Start(){
				
		Manejador1.SetActive(false);
		Destroy(Manejador2);
		Destroy(Manejador3);	
		Destroy(Manejador4);
		Debug.Log("funca");
		
		
		Debug.Log("funcas");
	}



	/*void OnDrawGizmos(){
		Gizmos.color = new Color(255f,40f,0f,255f);
		Gizmos.DrawSphere(transform.position + new Vector3(-tamaño/2, -tamaño/2, 0f), 0.2f);
		Gizmos.DrawSphere(transform.position + new Vector3(longitud -tamaño/2,  -tamaño/2, 0f), 0.2f);
		Gizmos.DrawSphere(transform.position + new Vector3(-tamaño/2, altura-tamaño/2, 0f), 0.2f);
		Gizmos.DrawSphere(transform.position + new Vector3( longitud -tamaño/2, altura -tamaño/2, 0f), 0.2f);
	}*/

}
