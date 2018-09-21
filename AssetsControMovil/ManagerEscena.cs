using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerEscena : MonoBehaviour {

	OSCenviaRotacion oer;
	OscEnvia oe;
	void Start () {
		oer = (OSCenviaRotacion)FindObjectOfType(typeof(OSCenviaRotacion));
		oe = (OscEnvia)FindObjectOfType(typeof(OscEnvia));		
	}

	public void LoadTouch(){
		oer.restart();
		SceneManager.LoadScene(0, LoadSceneMode.Single);
  }
	public void LoadModelo(){
		oe.enviarGetModelos();
		SceneManager.LoadScene(1, LoadSceneMode.Single);
	}
	public void LoadPartes(){
		oe.enviarGetPartes();
		SceneManager.LoadScene(2, LoadSceneMode.Single);
	}
}
