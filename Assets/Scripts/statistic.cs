using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
public class statistic : MonoBehaviour {
    public Text Username;
	public Text Mail;
	public Text Level1;
	public Text Level2;
	public Text status;
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
		/*Debug.Log ("Splitter 1 is : " + splitter [1]);
		/int.TryParse (splitter [1], out userstatistic);
		int.TryParse (splitter [3], out userstatistic1);
		result = userstatistic + userstatistic1;
		Debug.Log (result);
		accuracy [0] = userstatistic;
		accuracy [1] = userstatistic1;*/
	}
	
	// Update is called once per frame
	void Update () {
		if (result > 0 && result < 25) {
			status.text = "Newbie";
		} else if (result > 25 && result < 100)
			status.text = "Beginner";
		else if (result > 100 && result < 200)
			status.text = "ıntermediate";
		else if (result > 200 && result < 300)
			status.text = "Veteran";
		else 
			status.text = "";
    }

    IEnumerator stat(string uname)
    {/*
       WWWForm form = new WWWForm();
		form.AddField("usernamePost", uname);
        //form.AddField("passwordPost", pass);

		WWW site = new WWW(statURL,form);
        yield return site;
        Debug.Log(site.text);
*/

		WWWForm form = new WWWForm();
		form.AddField("usernamePost", uname);
		
		WWW site = new WWW(statURL,form);
		yield return site;
		Debug.Log (site.text);
		splitter = site.text.Split(char.Parse(","));
		Level1.text = "Arabian Dance";
		Level2.text = "Chinese Dance";
		Mail.text = splitter [4];
		result = int.Parse (splitter [1]) + int.Parse (splitter [3]);
		GameObject.Find ("filler1").GetComponent<Image> ().fillAmount = float.Parse(splitter[1])/100;
		GameObject.Find("Label1").GetComponent<Text>().text = splitter[1] + "%";
		//level1acc. = int.Parse (splitter [1]);
		Debug.Log ("Accuracy 1: " + level1acc);
		GameObject.Find ("filler2").GetComponent<Image> ().fillAmount =float.Parse(splitter[3])/100;
		GameObject.Find("Label2").GetComponent<Text>().text = splitter[3] + "%";
		//level2acc = int.Parse (splitter [3]);
		Debug.Log ("Accuracy 2: " + level2acc);
		Debug.Log ("result is : " + result);
    }
}
