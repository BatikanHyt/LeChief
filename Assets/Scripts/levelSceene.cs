using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
public class levelSceene : MonoBehaviour {
	public Image level1;
	public Image level2;
	public Image level3;
	public Image level4;
	// Use this for initialization
    public void backbutton()
    {
		SceneManager.LoadScene ("level Scene");
    }
	void Start () {
		if(levels.levelname.Contains("1in1")){
			level1.enabled = true;
			level2.enabled = false;
			level3.enabled = false;
			level4.enabled = false;
		}
		else if(levels.levelname.Contains("2in2")){
			level1.enabled = false;
			level2.enabled = true;
			level3.enabled = false;
			level4.enabled = false;
		}
		else if(levels.levelname.Contains("3in1")){
			level1.enabled = false;
			level2.enabled = false;
			level3.enabled = true;
			level4.enabled = false;
		}
		else{
			level1.enabled = false;
			level2.enabled = false;
			level3.enabled = false;
			level4.enabled = true;
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
