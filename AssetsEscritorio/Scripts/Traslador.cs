using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traslador : MonoBehaviour {

	public float velocidadDeTraslacion= 0.45f;
  //float x  = 0;
	//float y  = 0;
	//float z  = 0;
	bool reiniciarMouseAnterior;
	Vector3 posMouseAnterior, deltaPosMouse;
	Rotador rotador;
	OSC osc;

	void Start () {
		posMouseAnterior = new Vector3();
		deltaPosMouse = new Vector3();
		rotador = gameObject.GetComponent<Rotador>();
		osc = GameObject.FindWithTag("ManagerOSCUnico").GetComponent<OSC>();
	}

	void Update () {



		//x = transform.position.x;
		//y = transform.position.y;
		//z = transform.position.z;
	}

	 void OnMouseDrag(){
		 if( osc.mute
				 && !rotador.teclaControlPresionada
				 && (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
		 ){
			 if( reiniciarMouseAnterior ){
				 posMouseAnterior = Input.mousePosition;
				 reiniciarMouseAnterior = false;
			 }
			 deltaPosMouse = Input.mousePosition - posMouseAnterior;
			 posMouseAnterior = Input.mousePosition;

			 transform.Translate( Vector3.up * deltaPosMouse.y * velocidadDeTraslacion, Space.World );
			 transform.Translate( Vector3.right * deltaPosMouse.x * velocidadDeTraslacion, Space.World );

		 }else reiniciarMouseAnterior = true;
	 }

}
