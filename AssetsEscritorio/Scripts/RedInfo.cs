﻿using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using UnityEngine.UI;

public class RedInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text t = GetComponent<Text>();
		t.text = GetIP();
	}

	// Update is called once per frame
	void Update () {

	}

	public static string GetIP(){
      IPHostEntry host;
      string localIP = "?";
      host = Dns.GetHostEntry(Dns.GetHostName());
      foreach (IPAddress ip in host.AddressList){
          if (ip.AddressFamily == AddressFamily.InterNetwork){
              localIP = ip.ToString();
          }
      }
      return localIP;
  }
}
