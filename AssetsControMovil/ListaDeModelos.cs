using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ListaDeModelos : MonoBehaviour {
	public GameObject nombreBoton;
	public Canvas canvas;
	Button[] modelos_boton;
	//GameObject[] partes;
	GameObject[] botones;
	//string[] partes_nombre;
	Info info;
	public OscEnvia oe;
	//string modeloActual_nombre;

	void Start () {
		canvas.GetComponent<CanvasScaler>();//.referenceResolution = new Vector2 (Screen.width, Screen.height);
		info = (Info)FindObjectOfType(typeof(Info));
		oe = (OscEnvia)FindObjectOfType(typeof(OscEnvia));
		destruirPartes();
		setElementos();
	}


	void Update () {
		if(info.actualizar){
			destruirPartes();
			setElementos();
			info.setActualizar(false);
		}
	}

	void destruirPartes(){
		if(botones!=null){
			for(int i=0;i<botones.Length;i++){
				Destroy(botones[i]);
			}
		}
	}

	void setElementos(){
		//Transform tModelo = transform.GetChild(0).transform;
		int cant = info.modelosCant;
		//partes =  new GameObject[cant];
		modelos_boton =  new Button[cant];
		//solo =  new Toggle[cant];
		//transparencia =  new Toggle[cant];
		botones = new GameObject[cant];
		for(int i=0;i<cant;i++){
			int indice = i;

			//----getteo la parte del modelo que quiero y creando un puntero al objeto asi como una bandera de su estado de visibilidad
			/*GameObject obj = tModelo.GetChild(i).gameObject;
			obj.AddComponent<Parte>();
			partes[i] = obj;*/

			//----instancio una instancia del el prefab de boton para controlar las partes
			GameObject objUI = Instantiate(nombreBoton);

			//----proceso para modificar el tamanio y posicion del rectangulo contenedor del nombre
			objUI.transform.SetParent(canvas.transform);
			RectTransform rt = objUI.GetComponent<RectTransform>();
			rt.sizeDelta = new Vector2(Screen.width/1.3f,Screen.height/21);
			float w = rt.rect.width;
			float h = rt.rect.height;
			rt.anchoredPosition = new Vector2(w*0.55f,(-h*1.2f)*(i+1));
			//----proceso para modificar el texto del nombre
			GameObject t = objUI.transform.GetChild(0).gameObject;
			Text texto = t.GetComponent<Text>();
			texto.text = info.modelos_nombre[i];
			RectTransform rtTexto = t.GetComponent<RectTransform>();
			rtTexto.sizeDelta = new Vector2(w,h*0.9f);
			rtTexto.anchoredPosition = new Vector2(0,0);
			//----proceso para modificar el tamanio y tamanio de los botones
			/*GameObject toggle1 = objUI.transform.GetChild(1).gameObject;
			GameObject toggle2 = objUI.transform.GetChild(2).gameObject;
			GameObject toggle3 = objUI.transform.GetChild(3).gameObject;

			RectTransform rt1 = toggle1.GetComponent<RectTransform>();
			RectTransform rt2 = toggle2.GetComponent<RectTransform>();
			RectTransform rt3 = toggle3.GetComponent<RectTransform>();

			rt1.sizeDelta = new Vector2(h,h);
			rt2.sizeDelta = new Vector2(h,h);
			rt3.sizeDelta = new Vector2(h,h);

			rt1.anchoredPosition = new Vector2(w+h/2.0f,0);
			rt2.anchoredPosition = new Vector2(w+h/2.0f+h,0);
			rt3.anchoredPosition = new Vector2(w+h/2.0f+2.0f*h,0);*/

			Button bt = objUI.GetComponent<Button>();

			modelos_boton[indice] = bt;

			bt.onClick.AddListener(delegate {enTouch(bt,indice);});
			Debug.Log(texto.text+""+indice+" este es el indice agregado");
			//----guardo en un arregloun puntero a alobjeto del tag junto al mute el solo para destruirlos despues
			botones[i] = objUI;
		}
		/*partes_nombre = new string[partes.Length];
		for(int i=0;i<partes_nombre.Length;i++){
			partes_nombre[i] = partes[i].name;
		}*/
	}
	void enTouch(Button cual, int indice){
		oe.enviarModelo(indice);
	}
}




/*public class ListaDePartes : MonoBehaviour {


	public GameObject oscManager;*
	OscUISetup ous;

	int resetTimer = 0;
	bool deboReset =false;
	//boolean reseteando = false;
	void Start () {

		ous = oscManager.GetComponent<OscUISetup>();
	}

	public void reset(string man){
		destruirPartes();
		resetTimer = 10;
		deboReset = true;
		modeloActual_nombre = man;
	}






	public void setSolo(int cual){
		solo[cual].isOn = !solo[cual].isOn;
	}
	public void setMute(int cual){
		mute[cual].isOn = !mute[cual].isOn;
	}
	public void setTransparencia(int cual){
			transparencia[cual].isOn = !transparencia[cual].isOn;
	}


	void Update () {
		evaluarReset();
	}

//-----------uso esta funcion para asegurarme de que el modelo este cargado antes de cargar las partes
	void evaluarReset(){
		if(deboReset){
			resetTimer--;
			if(resetTimer<=0){
				setPartes();
				deboReset=false;
			}
		}
	}
}*/
