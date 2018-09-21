using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parte : MonoBehaviour {

	Material m_material;
	Material transparente;
	Renderer m_renderer;
	bool estaTransparente;
    void Start(){
			m_renderer = GetComponent<Renderer>();
      m_material = m_renderer.material;
			transparente = transform.parent.parent.GetComponent<ListaDeModelos>().materialTransparente;
		}

    void Update(){
    }

		public void cambiarMaterial(){
			if(estaTransparente){
				m_renderer.material = m_material;
				estaTransparente = false;
			}else{
				m_renderer.material = transparente;
				estaTransparente = true;
			}
		}

}
