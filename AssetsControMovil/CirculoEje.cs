using UnityEngine;
using System.Collections;

public class CirculoEje : MonoBehaviour {
	LineRenderer linea;
	int vertices = 20;
	void Start () {
		linea = gameObject.GetComponent<LineRenderer>();
		Vector3[] posiciones = new Vector3[vertices+1];

		for(int i=0;i<vertices;i++){
			float a = map(i,0,vertices,0,2*Mathf.PI);
			float x = transform.position.x+Mathf.Cos(a);
			float y = transform.position.y+Mathf.Sin(a);
			posiciones[i] = new Vector3(x,y,0);
		}
		posiciones[vertices] = new Vector3(posiciones[0].x,posiciones[0].y,posiciones[0].z);

    linea.SetVertexCount(vertices+1);
		linea.SetPositions(posiciones);
		}

	void Update () {

	}

	public float map(float viejoValor, float viejoMinimo, float viejoMaximo, float nuevoMinimo, float nuevoMaximo){

		float viejoRango = (viejoMaximo - viejoMinimo);
		float nuevoRango = (nuevoMaximo - nuevoMinimo);
		float nuevoValor = (((viejoValor - viejoMinimo) * nuevoRango) / viejoRango) + nuevoMinimo;

		return nuevoValor;
}

}
