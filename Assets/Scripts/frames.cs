using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class frames : MonoBehaviour 
{
	private Vector3 startpos;
	private Vector3 endpos;
	private Vector3 pos;
	private int count = 1;	
	public float speed = 1;
	public bool move = true;
	float ElapsedTime = 0;
    float FinishTime = 60f;

	string line1;
	string line2;
	StreamReader theReader = new StreamReader(levels.levelname, Encoding.Default);
	List<Vector3> posList = new List<Vector3>();

	// Use this for initialization
	void Start () 
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 120;
		line1 = theReader.ReadLine ();
		while(line1 != null) 
		{
			string[] entries1 = line1.Split(' ');
			pos = new Vector3(float.Parse(entries1[0]), -1*float.Parse(entries1[1]));
			posList.Add(pos);
			line1 = theReader.ReadLine();	
		}
		transform.position = posList[0];
		pos = posList[posList.Count - 1];
	}
	void Draw()
	{
		if (move)
		{
			endpos = posList[count];
			float dist = Vector3.Distance(transform.position,endpos);
			Vector3 velocity = Vector3.zero;
			float smoothTime = 0.3F;
			transform.position = Vector3.MoveTowards(transform.position,endpos, dist);  
			if(transform.position == pos)
				move = false;
			count += 1;

		}
	}

	// Update is called once per frame
	void Update ()
	{
		Draw();
	}
}
