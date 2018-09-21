using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListaDeModelos : MonoBehaviour {

	public GameObject[] modelos;
	public string[] nombres;
	public GameObject oscManager;
	private OscUISetup ous;
	ListaDePartes ldp;
	GameObject enJuego;
	public GameObject canvas;
	public Material materialTransparente;
	void Start () {
		ldp = GetComponent<ListaDePartes>();
		enJuego = Instantiate(modelos[0],transform,true);
		ldp.reset(modelos[0].name);
		nombres = new string[modelos.Length];
		for(int i=0;i<nombres.Length;i++){
			nombres[i] = modelos[i].name;
		}
		ous = oscManager.GetComponent<OscUISetup>();
	}

	// Update is called once per frame
	void Update () {

	}

	public void setModelo(int valor){
		ldp.reset(modelos[valor].name);
		Destroy(enJuego);
		enJuego = Instantiate(modelos[valor],transform,true);
	}

	public void enviar(){
		ous.enviarListaModelos(nombres);
	}
}
