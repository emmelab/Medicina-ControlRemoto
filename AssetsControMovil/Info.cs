using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour {

	public string modeloActual_nombre;
	//public Dictionary<string, int> modelos = new Dictionary<string, int>();
	public string[] modelos_nombre;
	//public int[] modelos_indice;
	public int modelosCant;
	//public Dictionary<string, int> partes = new Dictionary<string, int>();
	public string[] partes_nombre;
	//public int[] partes_indice;
	public int partesCant;
	private static bool created = false;
	public bool actualizar;
	void Awake()	{
			if (!created){
					DontDestroyOnLoad(this.gameObject);
					created = true;
					Debug.Log("Awake: " + this.gameObject);
			}else{
					Destroy(this.gameObject);
			}

	}

	void Start () {
		actualizar = false;
		modelos_nombre = new string[3];
		partes_nombre = new string[6];
			/*modelos.Add("Test1",0);
			modelos.Add("Test2",2);
			modelos.Add("Test3",4);

			partes.Add("TestPar1",0);
			partes.Add("TestPar2",2);
			partes.Add("TestPar3",4);
			partes.Add("TestPar4",1);
			partes.Add("TestPar5",3);
			partes.Add("TestPar6",6);*/

			modelos_nombre[0]="Test1";
			modelos_nombre[1]="Test2";
			modelos_nombre[2]="Test3";
			modelosCant = 3;

			partes_nombre[0]="TestPar1";
			partes_nombre[1]="TestPar2";
			partes_nombre[2]="TestPar3";
			partes_nombre[3]="TestPar4";
			partes_nombre[4]="TestPar5";
			partes_nombre[5]="TestPar6";
			partesCant = 6;
	}

	public void setModelos(string[] n){
		Debug.Log("Modelos Pasa");
		modelosCant = n.Length;
		modelos_nombre = new string[n.Length];
		//modelos_indice = new int[n.Length];
		for(int i=0;i<n.Length;i++){
			modelos_nombre[i] = n[i];
			//modelos_indice[i] = indice[i];
		}
		actualizar = true;
	}
	public void setPartes(string modeloActual_,string[] n){
		Debug.Log("Partes Pasa");
		modeloActual_nombre = modeloActual_;
		partesCant = n.Length;
		partes_nombre = new string[n.Length];
		//partes_indice = new int[n.Length];
		for(int i=0;i<n.Length;i++){
			partes_nombre[i] = n[i];
			//partes_indice[i] = indice[i];
		}
		actualizar = true;
	}
	public void setActualizar(bool b){
		actualizar = b;
	}

}
