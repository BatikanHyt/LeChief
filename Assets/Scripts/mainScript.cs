using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
public class mainScript : MonoBehaviour {

	private string sceeneName = "Profile";
	public void profileButton(){
		Application.LoadLevel (sceeneName);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
