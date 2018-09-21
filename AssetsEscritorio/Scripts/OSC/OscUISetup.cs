using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscUISetup : MonoBehaviour {
	public OSC osc;
	// Use this for initialization
	void Start () {
		osc = gameObject.GetComponent<OSC>();
		//osc.SetAddressHandler( "/getPartes" , enviarListaPartes );
		//osc.SetAddressHandler( "/getModelos" , enviarListaModelos );
	}

	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown( KeyCode.Space ) ) osc.cambiarMute();
	}

	public void enviarListaPartes(string nombre,string[] lista){
		OscMessage message = new OscMessage();
		message.address = "/setListaPartes";
		message.values.Add(nombre );
		Debug.Log(nombre);
		message.values.Add(lista.Length);
		Debug.Log(lista.Length);
		for(int i=0;i<lista.Length;i++){
			message.values.Add(lista[i]);
			Debug.Log(lista[i]+"|"+i);
		}
		osc.Send(message);
	}

	public void enviarListaModelos(string[] lista){
		OscMessage message = new OscMessage();
		message.address = "/setListaModelos";
		message.values.Add(lista.Length);
		Debug.Log(lista.Length);
		for(int i=0;i<lista.Length;i++){
			message.values.Add(lista[i]);
			Debug.Log(lista[i]+"|"+i);
		}
		osc.Send(message);
	}
}
