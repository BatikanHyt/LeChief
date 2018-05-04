using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class settingsmenu : MonoBehaviour {
	public AudioMixer audioMixer;

	public Dropdown resolutionDropdown;
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
	public void returnMenu(){
		SceneManager.LoadScene ("Main");
		
	}
	public void SetResolution(int resolutionındex){
		Resolution resolution = resolutions [resolutionındex];
		Screen.SetResolution (resolution.width, resolution.height,Screen.fullScreen);
	}

	public void SetVolume (float volume){
		Debug.Log (volume);
		audioMixer.SetFloat ("volume", volume);
	}
	public void SetFullScreen(bool isFullScreen){
		Screen.fullScreen = isFullScreen;
	}
}
