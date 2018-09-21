using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

	//public Canvas canvas;
	public CanvasGroup cg;
	public OSC osc;
	bool mute;
	float alfaMemoria;

	void Start () {
		cg = gameObject.GetComponent<CanvasGroup>();
		osc = GameObject.FindWithTag("ManagerOSCUnico").GetComponent<OSC>();
		setMute();
	}

	void Update () {
		if( mute != osc.mute ) setMute();
		if( cg.alpha != alfaMemoria ) cg.alpha = Mathf.Lerp( cg.alpha, alfaMemoria, 0.2f );
		if( Mathf.Abs( alfaMemoria - cg.alpha ) < 0.001f ) cg.alpha = alfaMemoria;
	}

	void setMute(){
		mute = osc.mute;
		alfaMemoria = mute? 1.0f : 0.0f;
		cg.interactable = mute;
	}

}
