using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
public class conductpage : MonoBehaviour {
	public static string songname;
	public void russianDance(){
		songname = "conducting/russiandance.txt";
		SceneManager.LoadScene ("frames");
	}
	public void arabianDance(){
		songname = "conducting/arabiandane.txt";
		SceneManager.LoadScene ("frames");
	}
	public void chineseDance(){
		songname = "conducting/chinadance.txt";
		SceneManager.LoadScene ("frames");
		
	}
	public void danceofReedpipes(){
		songname = "conducting/danceofreadpipes.txt";
		SceneManager.LoadScene ("frames");
	}
	public void miniatureOverture(){
		songname = "conducting/miniatureoverture.txt";
		SceneManager.LoadScene ("frames");
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
