using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
public class register : MonoBehaviour {
	//string createUserURL = "https://lechief.azurewebsites.net/register.php";
	string createUserURL = "localhost/lechief/register.php";
	public GameObject username;
	public GameObject password;
	public GameObject email;
	public GameObject fullname;

	private string Username;
	private string Password;
	private string Email;
	private string Fullname;
	private string form;
	private bool validEmail= false;
	private string sceneName = "login";
    // Use this for initialization
    void Start () {
	
	}
	public void RegisterButton(){
		StartCoroutine(CreateUser (Username, Password, Email, Fullname));

	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			if(username.GetComponent<InputField> ().isFocused)
				password.GetComponent<InputField>().Select();
			if(fullname.GetComponent<InputField> ().isFocused)
				username.GetComponent<InputField>().Select();
			if(password.GetComponent<InputField> ().isFocused)
				email.GetComponent<InputField>().Select();
			if(email.GetComponent<InputField> ().isFocused)
				fullname.GetComponent<InputField>().Select();
		}
		if (Input.GetKeyDown (KeyCode.Return)) {
			if(Password != ""  && Email !=""&& Username != "" && Fullname !=""){
				RegisterButton();
			}
		}
		Username = username.GetComponent<InputField> ().text;
		Email = email.GetComponent<InputField> ().text;
		Password = password.GetComponent<InputField> ().text;
		Fullname = fullname.GetComponent<InputField> ().text;
	
	}
	IEnumerator CreateUser(string uname, string pass, string mail, string name)
    {
        WWWForm form = new WWWForm();
		form.AddField("usernamePost", uname);
		form.AddField("passwordPost", pass);
		form.AddField("emailPost", mail);
		form.AddField("fullnamePost", name);

        WWW site = new WWW(createUserURL,form);
		yield return site;
		Debug.Log (site.text);
		if (site.text.Contains ("username exist")) {
			Debug.Log (site.text);
		} else {
			SceneManager.LoadScene (sceneName);
		}
    }
}
