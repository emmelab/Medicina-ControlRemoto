using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscRecibe : MonoBehaviour {
	public OSC osc;
	public Info info;
	void Start () {
		osc = gameObject.GetComponent<OSC>();
		osc.SetAddressHandler("/setListaPartes",setListaPartes);
		osc.SetAddressHandler("/setListaModelos",setListaModelos);
		//osc.SetAddressHandler("/test",testTexto);
		info = (Info)FindObjectOfType(typeof(Info));
	}

	void setListaPartes(OscMessage m){
		string nombre_modelo_actual = m.GetString(0);
		string[] nombres_partes = new string[m.GetInt(1)];
		for(int i=0;i<nombres_partes.Length;i++){
			nombres_partes[i] = m.GetString(2+i);
		}
		info.setPartes(nombre_modelo_actual,nombres_partes);
	}
	void setListaModelos(OscMessage m){
		string[] nombres_modelos = new string[m.GetInt(0)];
		Debug.Log(m.GetInt(0));
		for(int i=0;i<nombres_modelos.Length;i++){
			nombres_modelos[i] = m.GetString(1+i);
			Debug.Log(m.GetString(1+i));
		}
		info.setModelos(nombres_modelos);
	}

	/*void testTexto(OscMessage m){
		Debug.Log("Recibo");
		Debug.Log(m.GetString(0));;
	}
	public void enviarMensaje(){
		OscMessage mensaje = new OscMessage();
		mensaje.address = "/test";
		mensaje.values.Add("Esto es nu mensaje HOLI!");
		//Debug.Log(addrs);
		osc.Send(mensaje);
	}*/
}
