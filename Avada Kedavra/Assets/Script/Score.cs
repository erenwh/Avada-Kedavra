using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Score : MonoBehaviour {

	public int score;

	// Use this for initialization
	void Start () {
		score = 50;
	}
	
	public void addScore(int addition) {
		score += addition;
	}

	public void subScore(int subtraction) {
		score -= subtraction;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
