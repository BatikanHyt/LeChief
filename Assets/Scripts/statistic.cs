using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using TMPro;
public class statistic : MonoBehaviour {
    public Text Username;
	public Text Mail;
	public  Text status;
	//public string uname = Login.user;
	public static int level1acc;
	public static int level2acc;

	private string [] splitter;
	private int result;
	private int userstatistic;
	private int userstatistic1;
	private int userstatistic2;

    //string statURL = "https://lechief.azurewebsites.net/statistic.php";
	string statURL = "localhost/lechief/statistic.php";
    // Use this for initialization
	public void gobackButton(){
		SceneManager.LoadScene("Main");
	}
    void Start () {
		Username.text = Login.user;
		StartCoroutine(stat(Login.user));
	}
	
	// Update is called once per frame
	void Update () {
		if (result >= 0 && result < 100) {
			status.text = "Newbie";
		} else if (result >= 100 && result < 200)
			status.text = "Beginner";
		else if (result >= 200 && result < 300)
			status.text = "ıntermediate";
		else if (result >= 300 && result <= 400)
			status.text = "Veteran";
		else 
			status.text = "";
    }

    IEnumerator stat(string uname)
    {
		WWWForm form = new WWWForm();
		form.AddField("usernamePost", uname);
		
		WWW site = new WWW(statURL,form);
		yield return site;
		Debug.Log (site.text);
		splitter = site.text.Split(char.Parse(","));
		Mail.text = splitter [15];
		result = int.Parse (splitter [10]) + int.Parse (splitter [11])+int.Parse (splitter [12])+int.Parse (splitter [13]);

		GameObject.Find ("filler1").GetComponent<Image> ().fillAmount = float.Parse(splitter[10])/100;
		GameObject.Find("Label1").GetComponent<Text>().text = splitter[10] + "%";

		GameObject.Find ("filler2").GetComponent<Image> ().fillAmount =float.Parse(splitter[11])/100;
		GameObject.Find("Label2").GetComponent<Text>().text = splitter[11] + "%";

		GameObject.Find ("filler3").GetComponent<Image> ().fillAmount =float.Parse(splitter[12])/100;
		GameObject.Find("Label3").GetComponent<Text>().text = splitter[12] + "%";

		GameObject.Find ("filler4").GetComponent<Image> ().fillAmount =float.Parse(splitter[13])/100;
		GameObject.Find("Label4").GetComponent<Text>().text = splitter[13] + "%";
	
		GameObject.Find ("filler5").GetComponent<Image> ().fillAmount =float.Parse(splitter[14])/100;
		GameObject.Find("Label5").GetComponent<Text>().text = splitter[14] + "%";

    }
}
