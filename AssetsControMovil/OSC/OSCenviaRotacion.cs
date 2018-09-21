using UnityEngine;
using System.Collections;

public class OSCenviaRotacion : MonoBehaviour {
	//------ Este envia la matriz de transformacion del modelo
	public OSC osc;
	public Rotador rotador;
	public Scalador scalador;
	public Traslador traslador;
	bool deboReiniciar = true;
	int restartTime = 10;
  void Start () {
		osc = gameObject.GetComponent<OSC>();

	}
	public void restart(){
		deboReiniciar = true;
		restartTime = 10;
	}

	void Update () {
		if(deboReiniciar && restartTime<0){
			GameObject cubo = GameObject.FindWithTag("Modelo");
			if(cubo!=null){
				rotador = cubo.GetComponent<Rotador>();
				scalador = cubo.GetComponent<Scalador>();
				traslador = cubo.GetComponent<Traslador>();
			}
			deboReiniciar = false;
		}else if(restartTime>=0){
			restartTime--;
		}
		if(rotador!=null){
			enviarMensajeEscalacion();
			enviarMensajeTraslacion();
			enviarMensajeRotacion();
		}
	}

	void enviarMensajeRotacion(){
		OscMessage mensaje = new OscMessage();
		mensaje.address = "/setRot";
    mensaje.values.Add(rotador.getX());
		mensaje.values.Add(rotador.getY());
		mensaje.values.Add(rotador.getZ());
		osc.Send(mensaje);
	}

	void enviarMensajeTraslacion(){
		OscMessage mensaje = new OscMessage();
		mensaje.address = "/setPos";
    mensaje.values.Add(traslador.getX());
		mensaje.values.Add(traslador.getY());
		mensaje.values.Add(traslador.getZ());
		osc.Send(mensaje);
	}

	void enviarMensajeEscalacion(){
		OscMessage mensaje = new OscMessage();
		mensaje.address = "/setTam";
    mensaje.values.Add(scalador.getT());
		osc.Send(mensaje);
	}
}
