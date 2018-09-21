using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class m_SelectorDeModelo : MonoBehaviour {
	Dropdown m_Dropdown;
	public GameObject DisplayModelos;
	void Start () {
		m_Dropdown = GetComponent<Dropdown>();
		m_Dropdown.onValueChanged.AddListener(delegate {
                CambioValor(m_Dropdown);
            });
	}

	void Update(){

	}

	// Update is called once per frame
	void CambioValor(Dropdown opcion) {
			DisplayModelos.GetComponent<ListaDeModelos>().setModelo(opcion.value);
  }

	public void setValor(int opcion) {
			DisplayModelos.GetComponent<ListaDeModelos>().setModelo(opcion);
  }
}
