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
	public Image level5;
	// Use this for initialization
    public void backbutton()
    {
		SceneManager.LoadScene ("level Scene");
    }
	void Start () {
		if (levels.levelname.Contains ("1in1")) {
			level1.enabled = true;
			level2.enabled = false;
			level3.enabled = false;
			level4.enabled = false;
			level5.enabled = false;
		} else if (levels.levelname.Contains ("2in2")) {
			level1.enabled = false;
			level2.enabled = true;
			level3.enabled = false;
			level4.enabled = false;
			level5.enabled = false;
		} else if (levels.levelname.Contains ("3in1")) {
			level1.enabled = false;
			level2.enabled = false;
			level3.enabled = true;
			level4.enabled = false;
			level5.enabled = false;
		} else if (levels.levelname.Contains ("4in2")) {
			level1.enabled = false;
			level2.enabled = false;
			level3.enabled = false;
			level4.enabled = false;
			level5.enabled = true;
			
		} else if(levels.levelname.Contains("33in2")){
			level1.enabled = false;
			level2.enabled = false;
			level3.enabled = false;
			level4.enabled = true;
			level5.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
