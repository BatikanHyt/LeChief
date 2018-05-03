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
	public Image level2lock;
	public Image level3lock;
	public Image level4lock;
	private int level1star;
	private string [] splitter;
	private string levelUrl = "localhost/lechief/levels.php";
	private string levelstatUrl = "localhost/lechief/statistic.php";
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
		StartCoroutine (levelStat (Login.user));
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
			level2lock.enabled = false;
			button2.GetComponent<Button>().interactable = true;
			button3.GetComponent<Button>().interactable = false;
			button4.GetComponent<Button>().interactable = false;
		}
		else if (curLevel.Contains ("3")) {
			level2lock.enabled = false;
			level3lock.enabled = false;
			button2.GetComponent<Button>().interactable = true;
			button3.GetComponent<Button>().interactable = true;
			button4.GetComponent<Button>().interactable = false;
		}
		else if (curLevel.Contains ("4")) {
			level2lock.enabled = false;
			level3lock.enabled = false;
			level4lock.enabled = false;
			button2.GetComponent<Button>().interactable = true;
			button3.GetComponent<Button>().interactable = true;
			button4.GetComponent<Button>().interactable = true;
		}
	}
	IEnumerator levelStat(string uname){
		WWWForm form = new WWWForm ();
		form.AddField ("usernamePost", uname);

		WWW site = new WWW (levelstatUrl,form);
		yield return site;
		splitter = site.text.Split(char.Parse(","));
		int lvl1stat = int.Parse(splitter [0]);

		if(lvl1stat>0&&lvl1stat<=25)
			GameObject.Find("0star1").GetComponent<Image>().enabled = true;
		else if (lvl1stat>25 &&lvl1stat<=50)
			GameObject.Find("1star1").GetComponent<Image>().enabled = true;
		else if (lvl1stat>50 &&lvl1stat<=75)
			GameObject.Find("2star1").GetComponent<Image>().enabled = true;
		else if (lvl1stat>75 && lvl1stat<100)
			GameObject.Find("3star1").GetComponent<Image>().enabled = true;
		else
			GameObject.Find("empty1").GetComponent<Image>().enabled = true;
	}
}
