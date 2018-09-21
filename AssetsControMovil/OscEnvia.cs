using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscEnvia : MonoBehaviour {
	public OSC osc;
	void Start () {
		osc = gameObject.GetComponent<OSC>();
	}


	public void enviarModelo(int indice){
		enviarMensaje("/setModelo",indice);
	}
	public void enviarParte_solo(int indice){
		enviarMensaje("/setParteSolo",indice);
	}
	public void enviarParte_mute(int indice){
		enviarMensaje("/setParteMute",indice);
	}
	public void enviarParte_transparencia(int indice){
		enviarMensaje("/setParteTransparencia",indice);
	}
	public void enviarGetModelos(){
		enviarMensaje("/getModelos");
	}
	public void enviarGetPartes(){
		enviarMensaje("/getPartes");
	}
	void enviarMensaje(string addrs, int indice){
		OscMessage mensaje = new OscMessage();
		mensaje.address = addrs;
		mensaje.values.Add(indice);
		Debug.Log(addrs+"|"+indice);
		osc.Send(mensaje);
	}
	void enviarMensaje(string addrs){
		OscMessage mensaje = new OscMessage();
		mensaje.address = addrs;
		Debug.Log(addrs);
		osc.Send(mensaje);
	}
}
