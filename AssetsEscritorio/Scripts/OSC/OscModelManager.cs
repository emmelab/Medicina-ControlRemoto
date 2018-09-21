using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscModelManager : MonoBehaviour {
	public OSC osc;
	public m_SelectorDeModelo modelo;
	public ListaDePartes partes;
	void Start () {
		osc = gameObject.GetComponent<OSC>();
		osc.SetAddressHandler( "/setModelo" , enSetModelo );
		osc.SetAddressHandler( "/setParteSolo" , enSetParteSolo );
		osc.SetAddressHandler( "/setParteMute" , enSetParteMute );
		osc.SetAddressHandler( "/setParteTransparencia" , enSetParteTransparencia );
	}
	void enSetModelo(OscMessage message){
		int indice = message.GetInt(0);
		modelo.setValor(indice);
	}
	void enSetParteSolo(OscMessage message){
		int indice = message.GetInt(0);
		partes.setSolo(indice);
	}
	void enSetParteMute(OscMessage message){
		int indice = message.GetInt(0);
		partes.setMute(indice);
	}
	void enSetParteTransparencia(OscMessage message){
		int indice = message.GetInt(0);
		partes.setTransparencia(indice);
	}
}
