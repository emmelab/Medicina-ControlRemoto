using UnityEngine;
using System.Collections;

public class OSCrecibeRotacion : MonoBehaviour {
	public OSC osc;
	public Vector3 rotacion;
	public Vector3 posicion;
	public Vector3 escala;
	public MatrizDeEstado estado;
	public ListaDeModelos listaDeModelos;
	public ListaDePartes listaDePartes;
	// Use this for initialization
	void Start () {
		osc = gameObject.GetComponent<OSC>();
		estado = GameObject.FindWithTag("Modelo").GetComponent<MatrizDeEstado>();
		osc.SetAddressHandler( "/setRot" , enSetRot );
		osc.SetAddressHandler( "/setPos" , enSetPos );
		osc.SetAddressHandler( "/setTam" , enSetTam );
		osc.SetAddressHandler( "/getPartes" , enviarListaPartes );
		osc.SetAddressHandler( "/getModelos" , enviarListaModelos );
		rotacion = new Vector3(0,0,0);
		posicion = new Vector3(0,0,0);
		escala = new Vector3(0,0,0);
		listaDeModelos = GameObject.FindWithTag( "Modelo" ).GetComponent<ListaDeModelos>();
		listaDePartes = GameObject.FindWithTag( "Modelo" ).GetComponent<ListaDePartes>();
	}

	// Update is called once per frame
	void Update () {

	}

	/*Vector3 getRot(){
		return rotacion;
	}*/
	void enSetRot(OscMessage message){
		float x = message.GetFloat(0);
    float y = message.GetFloat(1);
		float z = message.GetFloat(2);
		rotacion.Set(x,y,z);
		estado.setRotacion(rotacion);
	}
	void enSetPos(OscMessage message){
		float x = message.GetFloat(0)*200;
    float y = message.GetFloat(1)*200;
		float z = message.GetFloat(2)*200;
		posicion.Set(x,y,z);
		estado.setPosicion(posicion);
	}
	void enSetTam(OscMessage message){
		float t = message.GetFloat(0);
		escala.Set(t,t,t);
		estado.setEscala(escala);
	}

	void enviarListaPartes(OscMessage message){
		listaDePartes.enviar();
	}

	void enviarListaModelos(OscMessage message){
		listaDeModelos.enviar();
	}

}
