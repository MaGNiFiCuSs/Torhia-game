using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[ExecuteInEditMode]
//requiere meshes para gameobject
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class TilesCutre : MonoBehaviour {

	public Vector3[] vertices;
	private Mesh mesh;


	public int altura;
	public int longitud;
	public bool Izquierda;
	public bool Derecha;
	public string tipo;
	public Vector2[] testuv;

	//on start empieza
	private void Awake () {
		StartCoroutine(Generar());
	}

    IEnumerator Generar() {
    	WaitForSeconds wait = new WaitForSeconds(0.05f);

    	//genera mesh
    	GetComponent<MeshFilter>().mesh = mesh = new Mesh();
		mesh.name = "Tiles Grid";


		//basura
		longitud += (Izquierda? 1 : 0)+ (Derecha? 1 : 0);
    	//genera vertices y uv y tangentes(normales)
        vertices = new Vector3[(altura + 1) * (longitud + 1 )];
        Vector2[] uv = new Vector2[vertices.Length];
        Vector4[] tangents = new Vector4[vertices.Length];
		Vector4 tangent = new Vector4(1f, 0f, 0f, -1f);



		/*Intento 1
		int i = 0, y = 0, x = 0;

		//basura
		if(Izquierda){
			for ( ; y <= altura; y++) {
				for (x = 0 ; x <= 1; x++, i++) {
					vertices[i] = new Vector3(x*470/300, y*649/300);
					uv[i] = new Vector2((float)x / longitud, (float)y / altura);
					tangents[i] = tangent;
					yield return wait;
				}
			}
		}
		//coloca vertices uv y tangentes
		
        for (  y = 0 ; y <= altura; y++) {
			for ( x = 0 + (Izquierda? 1 : 0); x <= longitud; x++, i++) {
				vertices[i] = new Vector3(x*740/300, y*649/300);
				uv[i] = new Vector2((float)x / longitud, (float)y / altura);
				tangents[i] = tangent;
				yield return wait;
			}
		}
		
		*/



		//intento2
		for (int i = 0, y = 0; y <= altura; y++) {
			for (int x = 0; x <= longitud; x++, i++) {

				if(x<=1&&Izquierda){
					vertices[i] = new Vector3((float)x*470/300, (float)y*649/300);
					} else if(x>=longitud&&Derecha){
						vertices[i] = new Vector3( (Izquierda ?  ((((float)x-1)*( (float)740/300)+( (float)470/300))-((float)270/300)) : (((float)x*740/300)-((float)270/300))) , (float)y*649/300);
					}else{
						vertices[i] = new Vector3( (Izquierda ? ((((float)x-1)*( (float)740/300)+( (float)470/300))) : ((float)x*740/300)) , (float)y*649/300);
					}




				uv[i] = new Vector2((float)x / longitud, (float)y / altura);
				testuv = uv;
				tangents[i] = tangent;
				yield return wait;
			}
		}
		







		mesh.vertices = vertices;
		mesh.uv = uv;
		mesh.tangents = tangents;
		
		//triangulos
		int[] triangulos = new int[longitud * altura * 6];
		for (int ti = 0, vi = 0, y2 = 0; y2 < altura; y2++, vi++){
			for (int x = 0; x < longitud; x++, ti += 6, vi++) {
			triangulos[ti] = vi;
			triangulos[ti+3] = triangulos[ti+2] = vi+ 1;
			triangulos[ti+4] = triangulos[ti+1] = longitud + vi + 1;
			triangulos[ti+5] = longitud + vi +2;

			mesh.triangles = triangulos;
			yield return wait;
			
			}
		}
		mesh.RecalculateNormals();
		
		
	
    }

    //muestra los vertices en editor
    void OnDrawGizmos () {
		Gizmos.color = Color.black;
		for (int i = 0; i < vertices.Length; i++) {
			Gizmos.DrawSphere(vertices[i], 0.1f);
		}
	}
  //mesh.uv2 = uvs2; esto es mio porque si

    
}
