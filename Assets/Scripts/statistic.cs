using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;

public class statistic : MonoBehaviour {
    public Text Username;
	public Text Mail;
    public Text Level1;
    public Text Level2;
    public Text status;
	//public string uname = Login.user;
	private string [] splitter;
	private int result;

    //string statURL = "https://lechief.azurewebsites.net/statistic.php";
	string statURL = "localhost/lechief/statistic.php";
    public string changed;
    // Use this for initialization
	public void gobackButton(){
		Application.LoadLevel("Main");
	}
    void Start () {
		Username.text = Login.user;
	}
	
	// Update is called once per frame
	void Update () {
            StartCoroutine(stat(Login.user));

		result = int.Parse(splitter [1]) + int.Parse(splitter [3]);
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
		Level1.text = "Level"+splitter [0] + " Your accuracy is : " + splitter [1];
		Level2.text = "Level"+splitter [2] + " Your Accuracy is : " + splitter [3];
		Mail.text = splitter [4];
    }
}
