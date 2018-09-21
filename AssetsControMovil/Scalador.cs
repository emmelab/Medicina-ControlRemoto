using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalador : MonoBehaviour {

	float velocidadDeEscalada= 0.01f;
  float t = 1;
	float tMemoria = 1;
	bool tocando;
	float distancia = 0;
	void Start () {

	}

	void Update () {

		if (Input.touchCount > 1){ //-- mas de un toque
			if (Input.GetTouch(0).phase == TouchPhase.Moved //--- dedo1 se mueve
			|| Input.GetTouch(1).phase == TouchPhase.Moved) //--- dedo2 se mueve
			{

	      Vector2 td1 = Input.GetTouch(0).position;//--- movimiento dedo1 en el ultimoframe
				Vector2 td2 = Input.GetTouch(1).position;//--- movimiento dedo2 en el ultimoframe
				if(tocando){
					float distanciaTemp = Vector2.Distance(td1,td2);
					t = tMemoria+velocidadDeEscalada*(distanciaTemp-distancia);
					//distancia = distanciaTemp;
				}else{
					distancia = Vector2.Distance(td1,td2);
					tocando = true;
					tMemoria = t;
				}
			}else{
				tocando = false;
			}
		}else{
			tocando = false;
		}

		transform.localScale = new Vector3(t,t,t);
	}

	public float getT(){
			return t;
	}
}
