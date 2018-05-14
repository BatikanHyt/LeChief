using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using Leap;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using System.Media;
using TMPro;

public class levelFrames : MonoBehaviour 
{
	public int accuracy;
	//SoundPlayer player = new SoundPlayer(@"C:\Users\Usman\Documents\GitHub\LeChief\RussianDance.wav");
	bool singing = false;
	bool startPlaying = false;
	float appX;
	float appY;
	public static float imageX;
	public static float imageY;
	public static float ballX;
	public static float ballY;
	string line1;
	string line2;
	private Vector3 startpos;
	private Vector3 endpos;
	private Vector3 pos;
	private Vector3 oldS;
	private Vector3 newS;
	private int count = 1;	
	private int count2 = 1;
	public float speed = 1;
	public bool move2 = true;
	public bool moveCheck = false;
	public float tim;
	float startTime = 0;
	float waitFor = 1.2f;
	//bool timerStart = false;
	//float ElapsedTime = 0;
	//float FinishTime = 60f;
	float appWidth = 1024;
	float appHeight = 768;
	StreamReader theReader = new StreamReader(levels.levelname, Encoding.Default);
	List<Vector3> posList = new List<Vector3>();
	GameObject ff;
	GameObject t;
	GameObject ball;
	Controller controller;
	Finger index;
	Frame frame;
	//Text tScore;
	int countBegining = 0;
	int score = 1000;
	//next page for statistic
	//public UnityEngine.UI.Image statisticpage;
	private GameObject subpage2;
	private TextMeshProUGUI proScore;
	private TextMeshProUGUI proAcc;
	private string updateLevelUrl = "localhost/lechief/updateLevels.php";
	private string unlockLevelUrl = "localhost/lechief/unlockLevel.php";
	private string levelUrl = "localhost/lechief/levels.php";
	private string statisticURL = "localhost/lechief/statistic.php";
	int lvl;
	int curLevel;
	int curLevelScore;
	private bool once;
	private string [] splitter;
	int GoodCount;
	int totalLine;
	private bool once1;



	// Use this for initialization
	void Start () 
	{
		foreach (Behaviour childCompnent in GameObject.Find("subpage2").GetComponentsInChildren<Behaviour>())
			childCompnent.enabled = false;
		StartCoroutine (currentProgress (Login.user));
		if (levels.levelname.Contains ("1in1"))
			lvl = 1;
		else if (levels.levelname.Contains ("2in2"))
			lvl = 2;
		else if (levels.levelname.Contains ("3in1"))
			lvl = 3;
		else if (levels.levelname.Contains ("33in2"))
			lvl = 4;
		else if (levels.levelname.Contains ("4in2"))
			lvl = 5;
		once = true;
		once1 = true;
		StartCoroutine(stat(Login.user,lvl));
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 30;
		ff = GameObject.Find("ff");
		t = GameObject.Find("t");
		ball = GameObject.Find("ball");
		/*tScore = GetComponent<Text>();
		tScore.fontSize = 30;
		tScore.text = score.ToString();
		*/
		controller = new Controller();
		index = new Finger();
		line1 = theReader.ReadLine ();
		while(line1 != null) 
		{
			string[] entries1 = line1.Split(' ');
			pos = new Vector3 (float.Parse (entries1 [0]) * appWidth / 1500, (-1 * float.Parse (entries1 [1]) + 1000) * appHeight / 1000);
			posList.Add(pos);
			line1 = theReader.ReadLine();
			line1 = theReader.ReadLine();
			line1 = theReader.ReadLine ();
			line1 = theReader.ReadLine();
			line1 = theReader.ReadLine();
			line1 = theReader.ReadLine ();
			line1 = theReader.ReadLine();
			line1 = theReader.ReadLine();
			line1 = theReader.ReadLine ();
			line1 = theReader.ReadLine();
			line1 = theReader.ReadLine();
			line1 = theReader.ReadLine ();
		}
		totalLine = posList.Count;
		//Debug.Log ("total line is : " + totalLine);
		ff.transform.position = posList[0];
		t.transform.position = ff.transform.position;
		pos = posList[posList.Count - 1];
	}
	void Hand()
	{

		InteractionBox iBox = controller.Frame().InteractionBox;
		frame = controller.Frame();
		List<Hand> handlist = new List<Hand>();
		for (int h = 0; h < frame.Hands.Count; h++)
		{
			Hand leapHand = frame.Hands[h];
			handlist.Add(leapHand);
		}
		index = frame.Hands[0].Fingers[(int)Finger.FingerType.TYPE_INDEX];
		if (index.IsExtended)
		{
			Vector fingPos = index.StabilizedTipPosition;
			Vector norm = iBox.NormalizePoint(fingPos, false);
			appX = norm.x * appWidth;
			appY = -1 * (1 - norm.y) * appHeight;
			imageX = t.transform.position.x;
			imageY = t.transform.position.y;
			ballX = ball.transform.position.x;
			ballY = ball.transform.position.y;
			float distanceX = ballX - imageX;
			float distanceY = ballY - imageY;
			if (Mathf.Abs(distanceX) < 50 && Mathf.Abs(distanceY) < 50)
			{
				//moveCheck = true;
				countBegining = 1;
				//ballX = imageX;
				//ballY = imageY;
				//ball.transform.position = t.transform.position;
				//ball.transform.parent = t.transform;
			}
			//if (Mathf.Abs (distanceX) < 100 && Mathf.Abs (distanceY) < 100) {
			//}
			Vector3 fPos = new Vector3(appX, appY);
			Plane objPlane = new Plane(Camera.main.transform.forward * -1, ball.transform.position);
			Ray mRay = Camera.main.ScreenPointToRay(fPos);
			float rayDistance;
			if (objPlane.Raycast(mRay, out rayDistance))
			{
				ball.transform.position = mRay.GetPoint(rayDistance);
				float d = Vector3.Distance(t.transform.position, ball.transform.position);
				if (d < 50)
				{

					ball.transform.position = t.transform.position;
					GoodCount++;
				}

			}
		}
	}
	void Draw()
	{

		if (move2)
		{
			endpos = posList[count];
			float dist = Vector3.Distance(ff.transform.position, endpos);
			ballX = ball.transform.position.x;
			ballY = ball.transform.position.y;
			if ((ballX == imageX && ballY == imageY) || countBegining == 1)
			{
				Vector3 velocity = Vector3.zero;
				//float smoothTime = 0.3F;
				ff.transform.position = Vector3.MoveTowards(ff.transform.position, endpos, dist);
				if (ff.transform.position == pos)
					move2 = false;
				count += 1;
				score = calculateScore(ballX, ballY, imageX, imageY, score);
				//------------------accuracy = CalculateAccuracy(score);
				//tScore.text = score.ToString();
				countBegining = 1;
				if (Time.time - startTime > waitFor) {
					Draw_t ();
					singing = true;
				}
			}
		}else {
			//Debug.Log ("Bitti");
			foreach (Behaviour childCompnent in GameObject.Find("subpage2").GetComponentsInChildren<Behaviour>())
				childCompnent.enabled = true;
			//proScore = GameObject.Find ("scoreShow").GetComponent<TextMeshProUGUI> ();
			proAcc = GameObject.Find ("accShow").GetComponent<TextMeshProUGUI> ();
			if (once1) {
				accuracy = (int)((100*GoodCount)/(totalLine));
				once1 = false;

				//proScore.text = score.ToString ();
				proAcc.text = accuracy.ToString () + "%";
				//StartCoroutine(stat(Login.user,lvl,curLevelScore));
				//Debug.Log ("CurlevelScore: " + curLevelScore + "accuracy compered: " + accuracy);
				if(curLevelScore < accuracy){
					StartCoroutine(statisticUpdater(score, accuracy, lvl, Login.user));
				}
				if (curLevel == lvl && once && curLevel != 5) {
					Debug.Log ("Current level : " + curLevel + " lvl param is: " + lvl);
					StartCoroutine (unlockLeveler (Login.user,curLevel+1));
					Debug.Log ("Currently online user: " + Login.user + "After curlevel : " + curLevel + "lvl is : " + lvl);
					once = false;
				}}
			//proScore.text = score;
			//proAcc.text = accuracy;*/

		}


	}



	void Draw_t ()
	{
		//		yield return new WaitForSeconds (1.5f);
		oldS = posList[count2];
		float dist = Vector3.Distance(t.transform.position,oldS);
		Vector3 velocity = Vector3.zero;
		t.transform.position = Vector3.MoveTowards(t.transform.position,oldS,dist);  
		count2 += 1;

	}

	// Update is called once per frame
	void Update ()
	{
		if (singing && !startPlaying)
		{
			// player.Play();
			startPlaying = true;
		}
		//Debug.Log ("Total Count is : " + (totalLine * 11.5));
		Hand();
		//if(moveCheck)
		Draw();

	}
	public static int calculateScore(float x1, float y1, float x2, float y2, int score)
	{

		var finalResult = CalculateDistance(x1, y1, x2, y2);

		//calculating score - we need to add popups in here.

		if (x1 != x2 && y1 != y2)
		{
			if (finalResult < 20 && score < 1000)// popup good.
			{
				score = score + 5;

			}
			else if (finalResult > 50 && finalResult < 60 && score >0) // popup you are getting far from the line!
			{
				score = score - 3;

			}
			else if (finalResult > 60 && finalResult < 70 && score >0) // popup you are getting far from the line!!
			{
				score = score - 4;

			}
			else if(score >0) // popup you are too far from the line!!!
			{
				score = score - 5;

			}

		}
		else if(score < 1000)
		{
			score = score + 10;

		}

		return score;

	}
	public static float CalculateDistance(float x1, float x2, float y1, float y2)
	{

		float temp1 = Mathf.Pow((x2 - x1), 2);
		float temp2 = Mathf.Pow((y2 - y1), 2);
		float result = Mathf.Sqrt(temp1 + temp2);

		return result;
	}
	/*
	public static int CalculateAccuracy(int score)
	{
		int temp = (score * 100) / 1000;
		return temp;
	}*/
	IEnumerator statisticUpdater (int score, int accuracy, int level, string username){
		WWWForm form = new WWWForm();
		form.AddField("usernamePost", username);
		form.AddField("accuracyPost", accuracy);
		form.AddField("levelPost", level);
		form.AddField("scorePost", score);
		WWW site = new WWW(updateLevelUrl,form);
		yield return site;
		Debug.Log (site.text);

	}
	//update the level
	IEnumerator unlockLeveler(string username, int svy){
		WWWForm form = new WWWForm();
		form.AddField("usernamePost", username);
		form.AddField ("levelPost", svy);
		WWW site = new WWW (unlockLevelUrl, form);
		yield return site;
		Debug.Log (site.text);
	}

	//getting current level
	IEnumerator currentProgress(string uname){
		WWWForm form = new WWWForm ();
		form.AddField ("usernamePost", uname);

		WWW site = new WWW (levelUrl, form);
		yield return site;
		curLevel = int.Parse(site.text);
		Debug.Log ("curLevel is : " + curLevel);
	}
	//getting levelStatistic
	IEnumerator stat (string uname, int now)
	{	
		WWWForm form = new WWWForm ();
		form.AddField ("usernamePost", uname);

		WWW site = new WWW (statisticURL, form);
		yield return site;
		splitter = site.text.Split(char.Parse(","));
		curLevelScore = int.Parse(splitter[now-1]);
	}
}