using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traslador : MonoBehaviour {

	float velocidadDeTraslacion= 0.01f;
  float x  = 0;
	float y  = 0;
	float z  = 0;

	float distancia = 0;
	void Start () {

	}

	void Update () {

		if (Input.touchCount > 1){ //-- mas de un toque
			if (Input.GetTouch(0).phase == TouchPhase.Moved //--- dedo1 se mueve
			&& Input.GetTouch(1).phase == TouchPhase.Moved //--- dedo2 se mueve
			){

	      Vector2 td1 = Input.GetTouch(0).deltaPosition;//--- movimiento dedo1 en el ultimoframe
				Vector2 td2 = Input.GetTouch(1).deltaPosition;//--- movimiento dedo2 en el ultimoframe

				float diferenciaDelAnguloDeMovimiento = Vector2.Distance(td1.normalized,td2.normalized);
				if(diferenciaDelAnguloDeMovimiento<0.5){
					Vector2 mov = (td1+td2)/2;
					transform.Translate(Vector3.up*mov.y*velocidadDeTraslacion,Space.World);
					transform.Translate(Vector3.right*mov.x*velocidadDeTraslacion,Space.World);
				}
			}
		}
		x = transform.position.x;
		y = transform.position.y;
		z = transform.position.z;

	}

	public float getX(){
			return x;
	}

	public float getY(){
			return y;
	}

	public float getZ(){
			return z;
	}
}
