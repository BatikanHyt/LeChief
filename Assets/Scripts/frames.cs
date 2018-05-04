using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using Leap;
using UnityEngine.UI;
using System.Media;
using TMPro;
using UnityEngine.SceneManagement;
public class frames : MonoBehaviour 
{	
	int accuracy;
	SoundPlayer player = new SoundPlayer(@conductpage.musicUrl);
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
 	bool timerStart = false;
	float ElapsedTime = 0;
    float FinishTime = 60f;
    float appWidth = 1024;
    float appHeight = 768;
	StreamReader theReader = new StreamReader(conductpage.songname, Encoding.Default);
	List<Vector3> posList = new List<Vector3>();
	GameObject ff;
	GameObject t;
    GameObject ball;
    Controller controller;
    Finger index;
    Frame frame;
    Text tScore;
    int countBegining = 0;
    int score = 100;
	int once = 1;
	int sayac = 0;

	private GameObject subpage2;
	private TextMeshProUGUI proScore;
	private TextMeshProUGUI proAcc;
	public void redirectToConductingPage(){
		SceneManager.LoadScene ("Main2");
	}

    // Use this for initialization
    void Start () 
	{
		foreach (Behaviour childCompnent in GameObject.Find("subpage2").GetComponentsInChildren<Behaviour>())
			childCompnent.enabled = false;
		Debug.Log (conductpage.songname);
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 30;
		ff = GameObject.Find("ff");
		t = GameObject.Find("t");
        ball = GameObject.Find("ball");
        tScore = GetComponent<Text>();
        tScore.fontSize = 30;
        tScore.text = score.ToString();
        controller = new Controller();
        index = new Finger();
        line1 = theReader.ReadLine ();
		while(line1 != null) 
		{
			string[] entries1 = line1.Split(' ');
			pos = new Vector3(float.Parse(entries1[0]) - appWidth / 4, float.Parse(entries1[1]) - appHeight / 2) ;
			posList.Add(pos);
			line1 = theReader.ReadLine();
			line1 = theReader.ReadLine();
		}
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
                ball.transform.parent = t.transform;
            }
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

                }

            }
        }

    }
    void Draw()
    {
		if (move2) {
			endpos = posList [count];
			float dist = Vector3.Distance (ff.transform.position, endpos);
			ballX = ball.transform.position.x;
			ballY = ball.transform.position.y;
			if ((ballX == imageX && ballY == imageY) || countBegining == 1) {
				sayac++;
				Vector3 velocity = Vector3.zero;
				float smoothTime = 0.3F;
				ff.transform.position = Vector3.MoveTowards (ff.transform.position, endpos, dist);
				if (ff.transform.position == pos)
					move2 = false;
				count += 1;
				score = calculateScore (ballX, ballY, imageX, imageY, score);

				tScore.text = score.ToString ();
				print ("Score is " + score);
				countBegining = 1;
				Debug.Log ("sayac: "+sayac);
				if (sayac > 30) {
					Draw_t ();
					singing = true;
				}
                    
			}
		} else {
			Debug.Log ("Bitti");
			foreach (Behaviour childCompnent in GameObject.Find("subpage2").GetComponentsInChildren<Behaviour>())
				childCompnent.enabled = true;
			proScore = GameObject.Find ("scoreShow").GetComponent<TextMeshProUGUI> ();
			proAcc = GameObject.Find ("accShow").GetComponent<TextMeshProUGUI> ();
			proScore.text = score.ToString ();
			proAcc.text = accuracy.ToString () + "%";
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
            player.Play();
            startPlaying = true;
			accuracy = CalculateAccuracy(score);
        }
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
                score = score - 1;
                
            }
			else if (finalResult > 60 && finalResult < 70 && score >0) // popup you are getting far from the line!!
            {
                score = score - 2;
                
            }
			else if(score >0) // popup you are too far from the line!!!
            {
                score = score - 3;
            
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
	public static int CalculateAccuracy(int score)
	{
		int temp = (score * 100) / 1000;
		return temp;

	}
	IEnumerator waitit(){
		yield return new WaitForSeconds (3);
	}
}
