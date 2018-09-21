using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReinicioOSC : MonoBehaviour {

    public OSC osc;
    public string nuevaIP = "";
    private static bool created = false;
    void Awake()    {
   		 if (!created){
   				 DontDestroyOnLoad(this.gameObject);
   				 created = true;
   				 Debug.Log("Awake: " + this.gameObject);
   		 }else{
   				 Destroy(this.gameObject);
   		 }

    }
  void Start () {
   	 osc = gameObject.GetComponent<OSC>();
    }

    public void ejecutar(){
   	 nuevaIP = GameObject.FindWithTag("InputIP").GetComponent<InputField>().text;
   	 osc.reiniciar(nuevaIP);
    }

    public void ejecutar(string s){
   	 osc.reiniciar(s);
    }
}
