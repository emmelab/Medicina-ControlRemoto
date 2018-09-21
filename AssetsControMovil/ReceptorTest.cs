using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptorTest : MonoBehaviour {
	public OSC osc;
	void Start () {
		osc = gameObject.GetComponent<OSC>();
		osc.SetAddressHandler("/test",test);

	}

	// Update is called once per frame
	void test (OscMessage m) {
		Debug.Log(" recivo "+ m.GetFloat(0));
	}
}
