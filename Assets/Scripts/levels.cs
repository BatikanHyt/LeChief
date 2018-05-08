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
	public Button button5;
	public Button button6;
	public Button button7;
	public Button button8;
	public Button button9;
	public Image level2lock;
	public Image level3lock;
	public Image level4lock;
	public Image level5lock;
	public Image level6lock;
	public Image level7lock;
	public Image level8lock;
	public Image level9lock;

	private int level1star;
	private string [] splitter;
	private string levelUrl = "localhost/lechief/levels.php";
	private string levelstatUrl = "localhost/lechief/statistic.php";
	private string curLevel;
	public static int currentLevel;
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
		Debug.Log ("Current level is : " + curLevel +"\n");
		if (curLevel.Contains ("1")) {
			currentLevel = 1;
			button2.GetComponent<Button>().interactable = false;
			button3.GetComponent<Button>().interactable = false;
			button4.GetComponent<Button>().interactable = false;
			button5.GetComponent<Button>().interactable = false;
			button6.GetComponent<Button>().interactable = false;
			button7.GetComponent<Button>().interactable = false;
			button8.GetComponent<Button>().interactable = false;
			button9.GetComponent<Button>().interactable = false;
		} 
		else if (curLevel.Contains ("2")) {
			currentLevel = 2;
			level2lock.enabled = false;
			button2.GetComponent<Button>().interactable = true;
			button3.GetComponent<Button>().interactable = false;
			button4.GetComponent<Button>().interactable = false;
			button5.GetComponent<Button>().interactable = false;
			button6.GetComponent<Button>().interactable = false;
			button7.GetComponent<Button>().interactable = false;
			button8.GetComponent<Button>().interactable = false;
			button9.GetComponent<Button>().interactable = false;

		}
		else if (curLevel.Contains ("3")) {
			currentLevel = 3;
			level2lock.enabled = false;
			level3lock.enabled = false;
			button2.GetComponent<Button>().interactable = true;
			button3.GetComponent<Button>().interactable = true;
			button4.GetComponent<Button>().interactable = false;
			button5.GetComponent<Button>().interactable = false;
			button6.GetComponent<Button>().interactable = false;
			button7.GetComponent<Button>().interactable = false;
			button8.GetComponent<Button>().interactable = false;
			button9.GetComponent<Button>().interactable = false;
		}
		else if (curLevel.Contains ("4")) {
			currentLevel = 4;
			level2lock.enabled = false;
			level3lock.enabled = false;
			level4lock.enabled = false;
			button2.GetComponent<Button>().interactable = true;
			button3.GetComponent<Button>().interactable = true;
			button4.GetComponent<Button>().interactable = true;
			button5.GetComponent<Button>().interactable = false;
			button6.GetComponent<Button>().interactable = false;
			button7.GetComponent<Button>().interactable = false;
			button8.GetComponent<Button>().interactable = false;
			button9.GetComponent<Button>().interactable = false;
		}
		else if (curLevel.Contains ("5")) {
			currentLevel = 4;
			level2lock.enabled = false;
			level3lock.enabled = false;
			level4lock.enabled = false;
			button2.GetComponent<Button>().interactable = true;
			button3.GetComponent<Button>().interactable = true;
			button4.GetComponent<Button>().interactable = true;
			button5.GetComponent<Button>().interactable = true;
			button7.GetComponent<Button>().interactable = false;
			button8.GetComponent<Button>().interactable = false;
			button9.GetComponent<Button>().interactable = false;

		}
		else if (curLevel.Contains ("6")) {
			currentLevel = 4;
			level2lock.enabled = false;
			level3lock.enabled = false;
			level4lock.enabled = false;
			button2.GetComponent<Button>().interactable = true;
			button3.GetComponent<Button>().interactable = true;
			button4.GetComponent<Button>().interactable = true;
			button5.GetComponent<Button>().interactable = true;
			button6.GetComponent<Button>().interactable = true;
			button7.GetComponent<Button>().interactable = false;
			button8.GetComponent<Button>().interactable = false;
			button9.GetComponent<Button>().interactable = false;
		}
		else if (curLevel.Contains ("7")) {
			currentLevel = 4;
			level2lock.enabled = false;
			level3lock.enabled = false;
			level4lock.enabled = false;
			button2.GetComponent<Button>().interactable = true;
			button3.GetComponent<Button>().interactable = true;
			button4.GetComponent<Button>().interactable = true;
			button5.GetComponent<Button>().interactable = true;
			button6.GetComponent<Button>().interactable = true;
			button7.GetComponent<Button>().interactable = true;
			button8.GetComponent<Button>().interactable = false;
			button9.GetComponent<Button>().interactable = false;
		}
		else if (curLevel.Contains ("8")) {
			currentLevel = 4;
			level2lock.enabled = false;
			level3lock.enabled = false;
			level4lock.enabled = false;
			button2.GetComponent<Button>().interactable = true;
			button3.GetComponent<Button>().interactable = true;
			button4.GetComponent<Button>().interactable = true;
			button4.GetComponent<Button>().interactable = true;
			button5.GetComponent<Button>().interactable = true;
			button6.GetComponent<Button>().interactable = true;
			button7.GetComponent<Button>().interactable = true;
			button8.GetComponent<Button>().interactable = true;
			button9.GetComponent<Button>().interactable = false;
		}
		else if (curLevel.Contains ("9")) {
			currentLevel = 4;
			level2lock.enabled = false;
			level3lock.enabled = false;
			level4lock.enabled = false;
			button2.GetComponent<Button>().interactable = true;
			button3.GetComponent<Button>().interactable = true;
			button4.GetComponent<Button>().interactable = true;
			button4.GetComponent<Button>().interactable = true;
			button5.GetComponent<Button>().interactable = true;
			button6.GetComponent<Button>().interactable = true;
			button7.GetComponent<Button>().interactable = true;
			button8.GetComponent<Button>().interactable = true;
			button9.GetComponent<Button>().interactable = true;
		}
	}
	IEnumerator levelStat(string uname){
		WWWForm form = new WWWForm ();
		form.AddField ("usernamePost", uname);

		WWW site = new WWW (levelstatUrl,form);
		yield return site;
		splitter = site.text.Split(char.Parse(","));
		int lvl1stat = int.Parse(splitter [0]);
		int lvl2stat = int.Parse (splitter [1]);
		int lvl3stat = int.Parse (splitter [2]);
		int lvl4stat = int.Parse (splitter [3]);
		int lvl5stat = int.Parse (splitter [4]);
		int lvl6stat = int.Parse (splitter [5]);
		int lvl7stat = int.Parse (splitter [6]);
		int lvl8stat = int.Parse (splitter [7]);
		int lvl9stat = int.Parse (splitter [8]);
		//for level 1
		if(lvl1stat>0&&lvl1stat<=25)
			GameObject.Find("0star1").GetComponent<Image>().enabled = true;
		else if (lvl1stat>25 &&lvl1stat<=50)
			GameObject.Find("1star1").GetComponent<Image>().enabled = true;
		else if (lvl1stat>50 &&lvl1stat<=75)
			GameObject.Find("2star1").GetComponent<Image>().enabled = true;
		else if (lvl1stat>75 && lvl1stat<=100)
			GameObject.Find("3star1").GetComponent<Image>().enabled = true;
		else
			GameObject.Find("empty1").GetComponent<Image>().enabled = true;

		//for level 2
		if(lvl2stat>0&&lvl2stat<=25)
			GameObject.Find("0star2").GetComponent<Image>().enabled = true;
		else if (lvl2stat>25 &&lvl2stat<=50)
			GameObject.Find("1star2").GetComponent<Image>().enabled = true;
		else if (lvl2stat>50 &&lvl2stat<=75)
			GameObject.Find("2star2").GetComponent<Image>().enabled = true;
		else if (lvl2stat>75 && lvl2stat<=100)
			GameObject.Find("3star2").GetComponent<Image>().enabled = true;
		else
			GameObject.Find("empty2").GetComponent<Image>().enabled = true;

		//for level3
		if(lvl3stat>0&&lvl3stat<=25)
			GameObject.Find("0star3").GetComponent<Image>().enabled = true;
		else if (lvl3stat>25 &&lvl3stat<=50)
			GameObject.Find("1star3").GetComponent<Image>().enabled = true;
		else if (lvl3stat>50 &&lvl3stat<=75)
			GameObject.Find("2star3").GetComponent<Image>().enabled = true;
		else if (lvl3stat>75 && lvl3stat<=100)
			GameObject.Find("3star3").GetComponent<Image>().enabled = true;
		else
			GameObject.Find("empty3").GetComponent<Image>().enabled = true;

		//for level4
		if(lvl4stat>0&&lvl4stat<=25)
			GameObject.Find("0star4").GetComponent<Image>().enabled = true;
		else if (lvl4stat>25 &&lvl4stat<=50)
			GameObject.Find("1star4").GetComponent<Image>().enabled = true;
		else if (lvl4stat>50 &&lvl4stat<=75)
			GameObject.Find("2star4").GetComponent<Image>().enabled = true;
		else if (lvl4stat>75 && lvl4stat<=100)
			GameObject.Find("3star4").GetComponent<Image>().enabled = true;
		else
			GameObject.Find("empty4").GetComponent<Image>().enabled = true;

		//for level5
		if(lvl5stat>0&&lvl5stat<=25)
			GameObject.Find("0star5").GetComponent<Image>().enabled = true;
		else if (lvl5stat>25 &&lvl5stat<=50)
			GameObject.Find("1star5").GetComponent<Image>().enabled = true;
		else if (lvl5stat>50 &&lvl5stat<=75)
			GameObject.Find("2star5").GetComponent<Image>().enabled = true;
		else if (lvl5stat>75 && lvl5stat<=100)
			GameObject.Find("3star5").GetComponent<Image>().enabled = true;
		else
			GameObject.Find("empty5").GetComponent<Image>().enabled = true;

		//for level6
		if(lvl6stat>0&&lvl6stat<=25)
			GameObject.Find("0star6").GetComponent<Image>().enabled = true;
		else if (lvl6stat>25 &&lvl6stat<=50)
			GameObject.Find("1star6").GetComponent<Image>().enabled = true;
		else if (lvl6stat>50 &&lvl6stat<=75)
			GameObject.Find("2star6").GetComponent<Image>().enabled = true;
		else if (lvl6stat>75 && lvl6stat<=100)
			GameObject.Find("3star6").GetComponent<Image>().enabled = true;
		else
			GameObject.Find("empty6").GetComponent<Image>().enabled = true;

		//for level7
		if(lvl7stat>0&&lvl7stat<=25)
			GameObject.Find("0star7").GetComponent<Image>().enabled = true;
		else if (lvl7stat>25 &&lvl7stat<=50)
			GameObject.Find("1star7").GetComponent<Image>().enabled = true;
		else if (lvl7stat>50 &&lvl7stat<=75)
			GameObject.Find("2star7").GetComponent<Image>().enabled = true;
		else if (lvl7stat>75 && lvl7stat<=100)
			GameObject.Find("3star7").GetComponent<Image>().enabled = true;
		else
			GameObject.Find("empty7").GetComponent<Image>().enabled = true;

		//for level8
		if(lvl8stat>0&&lvl8stat<=25)
			GameObject.Find("0star8").GetComponent<Image>().enabled = true;
		else if (lvl8stat>25 &&lvl8stat<=50)
			GameObject.Find("1star8").GetComponent<Image>().enabled = true;
		else if (lvl8stat>50 &&lvl8stat<=75)
			GameObject.Find("2star8").GetComponent<Image>().enabled = true;
		else if (lvl8stat>75 && lvl8stat<=100)
			GameObject.Find("3star8").GetComponent<Image>().enabled = true;
		else
			GameObject.Find("empty8").GetComponent<Image>().enabled = true;

		//for level9
		if(lvl9stat>0&&lvl9stat<=25)
			GameObject.Find("0star9").GetComponent<Image>().enabled = true;
		else if (lvl9stat>25 &&lvl9stat<=50)
			GameObject.Find("1star9").GetComponent<Image>().enabled = true;
		else if (lvl9stat>50 &&lvl9stat<=75)
			GameObject.Find("2star4").GetComponent<Image>().enabled = true;
		else if (lvl9stat>75 && lvl9stat<=100)
			GameObject.Find("3star9").GetComponent<Image>().enabled = true;
		else
			GameObject.Find("empty9").GetComponent<Image>().enabled = true;
	}
}
