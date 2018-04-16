using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;

public class statistic : MonoBehaviour {
    public Text Username;
    public Text Level1;
    public Text Level2;
    public Text currentLevel;
	public string username = Login.user;

    //string statURL = "https://lechief.azurewebsites.net/statistic.php";
	string statURL = "localhost/lechief/statistic.php";
    public string changed;
    // Use this for initialization
    void Start () {
		Username.text = username;
	}
	
	// Update is called once per frame
	void Update () {
            StartCoroutine(stat(username));
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
    }
}
