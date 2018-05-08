using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class settingsmenu : MonoBehaviour {
	public AudioMixer audioMixer;
	public InputField pass;
	public InputField passnew;
	public InputField passre;
	public Text invalid;
	private string Spass;
	private string Spassnew;
	private string Spassre;
	public Dropdown resolutionDropdown;
	private string changePassUrl = "localhost/lechief/updatePassword.php";
	Resolution[] resolutions;
	void Start(){
		resolutions = Screen.resolutions;
		resolutionDropdown.ClearOptions ();
		List<string> options = new List<string>();

		int currentResolutionındex = 0;
		for(int i = 0; i< resolutions.Length; i++){
			string option = resolutions[i].width + " x " + resolutions[i].height;
			options.Add(option);
			if (resolutions [i].width == Screen.currentResolution.width &&
				resolutions[i].height == Screen.currentResolution.height) {
				currentResolutionındex = i;
			}
		}
		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentResolutionındex;
		resolutionDropdown.RefreshShownValue ();
	}
	public void saveChanges(){
		if (Spass != "" && Spassnew != "" && Spassre != "" && Spassnew == Spassre) {
			invalid.text = " ";
			StartCoroutine (changePassword (Login.user, Spass, Spassnew));
		} else if (Spassnew != Spassre) {
			invalid.text = "Passwords dont match";
		}else if (Spass == "")
			invalid.text = "Please enter your password's credentials";
	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.Tab)) {
			if (pass.isFocused) {
				passnew.Select ();
			}
			if (passnew.isFocused) {
				passre.Select ();
			}
			if (passre.isFocused) {
				pass.Select ();
			}
		}
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (Spass != "" && Spassnew != "" && Spassre != "" && Spassnew == Spassre) {
				invalid.text = " ";
				saveChanges ();
			} else if (Spassnew != Spassre) {
				invalid.text = "Passwords dont match";
			}else 
				invalid.text = "Please enter your password's credentials";
		}
		Spass = pass.text;
		Spassnew = passnew.text;
		Spassre = passre.text;
	}
	public void returnMenu(){
		SceneManager.LoadScene ("Main");
		
	}
	public void SetResolution(int resolutionındex){
		Resolution resolution = resolutions [resolutionındex];
		Screen.SetResolution (resolution.width, resolution.height,Screen.fullScreen);
	}

	public void SetVolume (float volume){
		audioMixer.SetFloat ("volume", volume);
	}
	public void SetFullScreen(bool isFullScreen){
		Screen.fullScreen = isFullScreen;
	}
	IEnumerator changePassword(string username, string pass, string newpass){
		WWWForm form = new WWWForm();
		form.AddField("usernamePost", username);
		form.AddField("oldPost", pass);
		form.AddField("passwordPost", newpass);

		WWW site = new WWW(changePassUrl,form);
		yield return site;
		//Debug.Log ("Serverdan gelen : " + site.text);
		invalid.text = site.text;
	}
}
