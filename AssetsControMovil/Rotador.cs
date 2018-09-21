using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rotador : MonoBehaviour {

	float velocidadDeRotacion= 5f;
  float x = 0;
	float y = 0;
	float z = 0;

	Camera cam;
	Vector2 anteriorT1, anteriorT2;

	void Start () {
		cam = Camera.main;
	}

	void Update () {

		/*//if( Input.touchCount > 0 ){ // 1
			Debug.Log( "soy cubo: " + transform.position );

			Vector2 quieroVer = cam.WorldToScreenPoint( transform.position );
			Debug.Log( "soy quieroVer: " + quieroVer );
			//Vector2 actualT2 = ( (Vector2)(transform.position) - Input.GetTouch( 1 ).position );
		//}*/

		x = gameObject.transform.eulerAngles.x;
		y = gameObject.transform.eulerAngles.y;
		z = gameObject.transform.eulerAngles.z;
	}

	void OnMouseDrag(){
		if( !(Input.touchCount > 1) ){
			float rotX = Input.GetAxis("Mouse X")*velocidadDeRotacion;
			float rotY = Input.GetAxis("Mouse Y")*velocidadDeRotacion;

			transform.Rotate(Vector3.up*-rotX, Space.World);
			transform.Rotate(Vector3.right*rotY, Space.World);
		}
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
