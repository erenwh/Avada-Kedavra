using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public GameObject scoreManager;
    public GameObject mtext;
    public GameObject PlayerHealth;
	public GameObject wand1;
	public GameObject wand2;
	public GameObject wand3;
    public GameObject wand;
	public int enemyNum;
	public bool left;

    // Use this for initialization
    void Start () {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
		enemyNum = 0;
    }
	
	// Update is called once per frame
	void Update () {
		if (left == true) {
			mtext.GetComponent<Text>().text = "Score : "  + scoreManager.GetComponent<Score>().score 
		+ "\n Damage : " + wand.GetComponent<GunController>().damage + "\n" + "Pink Statue Health : " 
		+ wand1.GetComponent<Target>().health + "\n" + "Green Statue Health : "
		+ wand2.GetComponent<Target>().health + "\n" + "Yellow Statue Health : "
		+ wand3.GetComponent<Target>().health;
		}
		else 
		{
			mtext.GetComponent<Text>().text = "Shoot by Drawing : ";
		}
	}
}
