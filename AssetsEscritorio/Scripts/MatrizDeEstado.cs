using UnityEngine;
using System.Collections;

public class MatrizDeEstado : MonoBehaviour {

	Vector3 r;
	Vector3 p;
	Vector3 e;
	void Start () {
		r = new Vector3(0,0,0);
		p = new Vector3(0,0,0);
		e = new Vector3(0,0,0);
	}

	void Update () {

	}

	public void setRotacion(Vector3 v){
		r.Set(v.x,v.y,v.z);
		gameObject.transform.eulerAngles = r;
	}
	public void setPosicion(Vector3 v){
		p.Set(v.x,v.y,v.z);
		gameObject.transform.position = p;
	}
	public void setEscala(Vector3 v){
		e.Set(v.x,v.y,v.z);
		gameObject.transform.localScale = e;
	}
}
