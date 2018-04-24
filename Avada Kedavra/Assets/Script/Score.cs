using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Score : MonoBehaviour {

    public bool scoreLock = true;

    public GameObject cap1;
    public GameObject cap2;
    public GameObject cap3;
    public GameObject bitch;

    public int score;

	// Use this for initialization
	void Start () {
		score = 50;
	}
	
	public void addScore(int addition) {
        if (scoreLock == true)
        {
            score += addition;
        }
	}

	public void subScore(int subtraction) {
        if (scoreLock == true)
        {
            score -= subtraction;
        }
    }

	// Update is called once per frame
	void Update () {
		if (cap1.GetComponent<Target>().dead == true && cap2.GetComponent<Target>().dead == true && cap3.GetComponent<Target>().dead == true && bitch.GetComponent<Target>().canTP == true)
        {
            Debug.Log("LOST BITCH");
            bitch.GetComponent<Target>().canTP = false;
            bitch.transform.position = new Vector3(0f, 0f, 271f);
            scoreLock = false;
        }
	}
}
