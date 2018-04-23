using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
public class mainScript : MonoBehaviour {

	private string sceeneName = "Profile";
	public void profileButton(){
		SceneManager.LoadScene (sceeneName);
	}
	public void levelButton(){
		SceneManager.LoadScene ("level Scene");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
