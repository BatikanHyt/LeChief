using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
public class Login : MonoBehaviour {
	public static string user;
	public GameObject username;
	public GameObject password;
	public Text invalidwarning;
	private string Username;
	private string Password;
	private string form;
	private string sceneName = "Main";
	private string signScene = "SignUp";
	//string loginUrl = "https://lechief.azurewebsites.net/login.php";
	string loginUrl = "localhost/lechief/login.php";
	// Use this for initialization
	void Start () {
		invalidwarning.text = "";
	
	}
	public void loginButton(){
		StartCoroutine(login (Username, Password));

	}
	public void singupButton(){
		SceneManager.LoadScene (signScene);
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			if(username.GetComponent<InputField> ().isFocused)
				password.GetComponent<InputField>().Select();
			if(password.GetComponent<InputField> ().isFocused)
				username.GetComponent<InputField>().Select();
		}
		if (Input.GetKeyDown (KeyCode.Return)) {
			if(Password != ""  && Username != "" ){
				loginButton();
			}
		}
		Username = username.GetComponent<InputField> ().text;
		Password = password.GetComponent<InputField> ().text;
	}

	IEnumerator login(string uname, string pass)
	{
		WWWForm form = new WWWForm();
		form.AddField("usernamePost", uname);
		form.AddField("passwordPost", pass);
		
		WWW site = new WWW(loginUrl,form);
		yield return site;
		Debug.Log (site.text);
		String txt = site.text;
		if (txt.Contains ("login success")) {
			user = uname;
			SceneManager.LoadScene (sceneName);
		} else {
			invalidwarning.text = txt;
		}

	}
}
