using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotador : MonoBehaviour {

	public float velocidadDeRotacion= 5f;
  //float x = 0;
	//float y = 0;
	//float z = 0;
	public bool teclaControlPresionada = false;
	OSC osc;

	void Start () {
		osc = GameObject.FindWithTag("ManagerOSCUnico").GetComponent<OSC>();
	}

	void Update () {
		teclaControlPresionada = Input.GetKey( KeyCode.LeftShift )? true : false;
		//x = gameObject.transform.eulerAngles.x;
		//y = gameObject.transform.eulerAngles.y;
		//z = gameObject.transform.eulerAngles.z;
	}

	void OnMouseDrag(){
		if( osc.mute && teclaControlPresionada ){
			float rotX = Input.GetAxis("Mouse X")*velocidadDeRotacion;
			float rotY = Input.GetAxis("Mouse Y")*velocidadDeRotacion;

			transform.Rotate(Vector3.up*-rotX, Space.World);
			transform.Rotate(Vector3.right*rotY, Space.World);
		}
	}

}
