using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ListaDePartes : MonoBehaviour {

	public GameObject nombreTag;
	public GameObject oscManager;
	OscUISetup ous;
	public Canvas canvas;
	Toggle[] mute;
	Toggle[] solo;
	Toggle[] transparencia;
	GameObject[] partes;
	GameObject[] partes_tag;
	string[] partes_nombre;
	string modeloActual_nombre;
	int resetTimer = 0;
	bool deboReset =false;
	Transform barraDeScroll;
	//boolean reseteando = false;
	void Start () {
		canvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2 (Screen.width, Screen.height);
		barraDeScroll = canvas.transform.GetChild(2).GetChild(0).GetChild(0).transform;
		ous = oscManager.GetComponent<OscUISetup>();
	}

	public void reset(string man){
		destruirPartes();
		resetTimer = 10;
		deboReset = true;
		modeloActual_nombre = man;
	}

	public void enviar(){
		ous.enviarListaPartes(modeloActual_nombre, partes_nombre);
	}

	void destruirPartes(){
		if(partes_tag!=null){
			for(int i=0;i<partes_tag.Length;i++){
				Destroy(partes_tag[i]);
			}
		}
	}

	void setPartes(){
		Transform tModelo = transform.GetChild(0).transform;
		partes =  new GameObject[tModelo.childCount];
		mute =  new Toggle[tModelo.childCount];
		solo =  new Toggle[tModelo.childCount];
		transparencia =  new Toggle[tModelo.childCount];
		partes_tag = new GameObject[tModelo.childCount];
		float anchoTag = Screen.width/5.5f;
		float altoTag = Screen.height/27;
		for(int i=0;i<tModelo.childCount;i++){
			int indice = i;

			//----getteo la parte del modelo que quiero y creando un puntero al objeto asi como una bandera de su estado de visibilidad
			GameObject obj = tModelo.GetChild(i).gameObject;
			obj.AddComponent<Parte>();
			partes[i] = obj;
			//----instancio una instancia del el prefab de boton para controlar las partes
			GameObject objUI = Instantiate(nombreTag);

			//----proceso para modificar el tamanio y posicion del rectangulo contenedor del nombre
			objUI.transform.SetParent(barraDeScroll);//----- agrego el objeto dentro del scroll
			RectTransform rt = objUI.GetComponent<RectTransform>();

			rt.sizeDelta = new Vector2(anchoTag,altoTag);
			float w = rt.rect.width;
			float h = rt.rect.height;
			rt.anchoredPosition = new Vector2(w*0.5f,(-h*1f)*(i+0.5f));
			//----proceso para modificar el texto del nombre
			GameObject t = objUI.transform.GetChild(0).gameObject;
			Text texto = t.GetComponent<Text>();
			texto.text = obj.name;
			RectTransform rtTexto = t.GetComponent<RectTransform>();
			rtTexto.sizeDelta = new Vector2(w,h*0.9f);
			rtTexto.anchoredPosition = new Vector2(0,0);
			//----proceso para modificar el tamanio y tamanio de los botones
			GameObject toggle1 = objUI.transform.GetChild(1).gameObject;
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
			rt3.anchoredPosition = new Vector2(w+h/2.0f+2.0f*h,0);

			Toggle tgl1 = toggle1.GetComponent<Toggle>();
			Toggle tgl2 = toggle2.GetComponent<Toggle>();
			Toggle tgl3 = toggle3.GetComponent<Toggle>();

			tgl1.isOn = false;
			tgl2.isOn = false;
			tgl3.isOn = false;

			mute[indice] = tgl1;
			solo[indice] = tgl2;
			transparencia[indice] = tgl3;

			tgl1.onValueChanged.AddListener(delegate {cambiaUnTogleMute(tgl1,indice);});
			tgl2.onValueChanged.AddListener(delegate {cambiaUnTogleSolo(tgl2,indice);});
			tgl3.onValueChanged.AddListener(delegate {cambiaUnTogleTransparencia(tgl3,indice);});
			//----guardo en un arregloun puntero a alobjeto del tag junto al mute el solo para destruirlos despues
			partes_tag[i] = objUI;
		}
		partes_nombre = new string[partes.Length];
		for(int i=0;i<partes_nombre.Length;i++){
			partes_nombre[i] = partes[i].name;
		}
	}

	void cambiaUnTogleMute(Toggle cual, int indice){
		bool haySolo	= false;
		for(int i=0;i<partes.Length;i++){
			if(solo[i].isOn){
				haySolo = true;
			}
		}

		if(!haySolo){
			for(int i=0;i<partes.Length;i++){
					if(mute[i].isOn){
						partes[i].SetActive(false);
					}else{
						partes[i].SetActive(true);
					}
			}
		}
	}

	void cambiaUnTogleSolo(Toggle cual, int indice){
		if(cual.isOn){
			for(int i=0;i<partes.Length;i++){
				if(solo[i].isOn){
					partes[i].SetActive(true);
				}else{
					partes[i].SetActive(false);
				}
			}
		}else{
			bool haySolo	= false;
			for(int i=0;i<partes.Length;i++){
					if(solo[i].isOn){
						haySolo = true;
					}
			}
			if(haySolo){
				partes[indice].SetActive(cual.isOn);
			}else{
				for(int i=0;i<partes.Length;i++){
					if(mute[i].isOn){
						partes[i].SetActive(false);
					}else{
						partes[i].SetActive(true);
					}
				}
			}
		}
	}

	void cambiaUnTogleTransparencia(Toggle cual, int indice){
		partes[indice].GetComponent<Parte>().cambiarMaterial();
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
}
