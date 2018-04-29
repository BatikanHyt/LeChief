using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
public class levels : MonoBehaviour {
	public static string levelname;
	public Button button1;
	public Button button2;
	public Button button3;
	public Button button4;
	private int level1star;
	private string levelUrl = "localhost/lechief/levels.php";
	private string curLevel;
	public void mainMenu(){
		SceneManager.LoadScene ("main");
	}
	public void profile(){
		SceneManager.LoadScene ("profile");
	}
	public void level1(){
		levelname = "metronom/1in1.txt";
		SceneManager.LoadScene ("drawer");
	}

	public void level2(){
		levelname = "metronom/2in2.txt";
		SceneManager.LoadScene ("drawer");
	}
	public void level3(){
		levelname = "metronom/3in1.txt";
		SceneManager.LoadScene ("drawer");
	}
	public void level4(){
		levelname = "metronom/33in2.txt";
		SceneManager.LoadScene ("drawer");
	}
	// Use this for initialization
	void Start () {
		StartCoroutine(currentProgress (Login.user));
		Debug.Log ("Accuracy: " + statistic.level1acc);
		if(statistic.level1acc<=25)
			GameObject.Find("0star1").GetComponent<Image>().enabled = true;
		else if (statistic.level1acc>25 && statistic.level1acc<=50)
			GameObject.Find("1star1").GetComponent<Image>().enabled = true;
		else if (statistic.level1acc>50 && statistic.level1acc<=75)
			GameObject.Find("2star1").GetComponent<Image>().enabled = true;
		else if (statistic.level1acc>75 && statistic.level1acc<100)
			GameObject.Find("3star1").GetComponent<Image>().enabled = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator currentProgress(string uname){
		WWWForm form = new WWWForm();
		form.AddField("usernamePost", uname);

		WWW site = new WWW(levelUrl,form);
		yield return site;
		curLevel = site.text;
		Debug.Log ("Current level is : " + curLevel);
		if (curLevel.Contains ("1")) {
			button2.GetComponent<Button>().interactable = false;
			button3.GetComponent<Button>().interactable = false;
			button4.GetComponent<Button>().interactable = false;
		} 
		else if (curLevel.Contains ("2")) {
			button2.GetComponent<Button>().interactable = true;
			button3.GetComponent<Button>().interactable = false;
			button4.GetComponent<Button>().interactable = false;
		}
		else if (curLevel.Contains ("3")) {
			button2.GetComponent<Button>().interactable = true;
			button3.GetComponent<Button>().interactable = true;
			button4.GetComponent<Button>().interactable = false;
		}
		else if (curLevel.Contains ("4")) {
			button2.GetComponent<Button>().interactable = true;
			button3.GetComponent<Button>().interactable = true;
			button4.GetComponent<Button>().interactable = true;
		}
	}
}
