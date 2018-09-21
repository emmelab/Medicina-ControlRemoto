using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalador : MonoBehaviour {

	float velocidadDeEscalada = -0.1f;
	float t = 1;
	OSC osc;

	void Start () {
		osc = GameObject.FindWithTag("ManagerOSCUnico").GetComponent<OSC>();
	}

	void Update () {
		if( osc.mute ){
			t = t * (1-(Input.mouseScrollDelta.y * velocidadDeEscalada));
			t = Mathf.Clamp( t, 0.4f, 10.0f );
			transform.localScale = new Vector3(t,t,t);
		}
	}
}
