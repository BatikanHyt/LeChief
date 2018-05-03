using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
public class conductpage : MonoBehaviour {
	public static string songname;
	public static string musicUrl;
	public void goMain(){
		SceneManager.LoadScene ("Main");
	}
	public void russianDance(){
		songname = "conducting/russiandance.txt";
		musicUrl = "musics/RussianDance.wav";
		SceneManager.LoadScene ("frames");
	}
	public void arabianDance(){
		songname = "conducting/arabiandane.txt";
		musicUrl = "musics/ArabianDance.wav";
		SceneManager.LoadScene ("frames");
	}
	public void chineseDance(){
		songname = "conducting/chinadance.txt";
		musicUrl = "musics/ChineseDance.wav";
		SceneManager.LoadScene ("frames");
		
	}
	public void danceofReedpipes(){
		songname = "conducting/danceofreadpipes.txt";
		musicUrl = "musics/DanceOfTheReedPipes.wav";
		SceneManager.LoadScene ("frames");
	}
	public void miniatureOverture(){
		songname = "conducting/miniatureoverture.txt";
		musicUrl = "musics/ArbianDance.wav";
		SceneManager.LoadScene ("frames");
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
