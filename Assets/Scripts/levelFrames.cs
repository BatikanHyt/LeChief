using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using Leap;

public class levelFrames : MonoBehaviour 
{
	
	private Vector3 startpos;
	private Vector3 endpos;
	private Vector3 pos;
	private Vector3 oldS;
	private Vector3 newS;
	private int count = 1;	
	private int count2 = 1;
	public float speed = 1;
	public bool move = true;
	public float tim;
	float startTime = 0;
 	float waitFor = 1.2f;
 	bool timerStart = false;
	float ElapsedTime = 0;
    float FinishTime = 60f;
    float appWidth = 1024;
    float appHeight = 768;
	string line1;
	string line2;
	StreamReader theReader = new StreamReader(levels.levelname, Encoding.Default);
	List<Vector3> posList = new List<Vector3>();
	GameObject ff;
	GameObject t;
    GameObject ball;
    Controller controller;
    Finger index;
    Frame frame;
 

    // Use this for initialization
    void Start () 
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 30;
		ff = GameObject.Find("ff");
		t = GameObject.Find("t");
        ball = GameObject.Find("ball");
        controller = new Controller();
        index = new Finger();
        line1 = theReader.ReadLine ();
		while(line1 != null) 
		{
			string[] entries1 = line1.Split(' ');
			pos = new Vector3(float.Parse(entries1[0]) - appWidth / 4, float.Parse(entries1[1]) - appHeight / 2) ;
			posList.Add(pos);
			line1 = theReader.ReadLine();	
		}
		ff.transform.position = posList[0];
		t.transform.position = ff.transform.position;
		pos = posList[posList.Count - 1];
		StartCoroutine("Draw_t");
	}
	void Draw()
	{
		if (move) 
		{
			endpos = posList[count];
			float dist = Vector3.Distance(ff.transform.position,endpos);
			float dist2 = Vector3.Distance(t.transform.position,oldS);
			Vector3 velocity = Vector3.zero;
			float smoothTime = 0.3F;
			ff.transform.position = Vector3.MoveTowards(ff.transform.position,endpos,dist);  
			if(ff.transform.position == pos)
				move = false;
			count += 1;

		}
	}

	void Draw_t ()
	{
//		yield return new WaitForSeconds (1.5f);
		oldS = posList[count2];
		float dist = Vector3.Distance(t.transform.position,oldS);
		Vector3 velocity = Vector3.zero;
		float smoothTime = 0.3F;
		t.transform.position = Vector3.MoveTowards(t.transform.position,oldS,dist);  
		count2 += 1;

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
            float appX = norm.x * appWidth;
            float appY = -1 * (1 - norm.y) * appHeight;
            Vector3 fPos = new Vector3(appX, appY);
            Plane objPlane = new Plane(Camera.main.transform.forward * -1, ball.transform.position);
            Ray mRay = Camera.main.ScreenPointToRay(fPos);
            float rayDistance;
            if (objPlane.Raycast(mRay, out rayDistance))
               ball.transform.position = mRay.GetPoint(rayDistance);
            print(fPos);
         }
    }
        // Update is called once per frame
    void Update ()
	{
		Draw();
		if (Time.time - startTime > waitFor)
     		Draw_t();
        Hand();
	}
}
