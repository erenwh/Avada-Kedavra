using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public GameObject scoreManager;
    public GameObject mtext;
    public GameObject PlayerHealth;
    public GameObject wand;

    // Use this for initialization
    void Start () {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
    }
	
	// Update is called once per frame
	void Update () {
        mtext.GetComponent<Text>().text = "Score : " + scoreManager.GetComponent<Score>().score + "\n" + "Health : " + PlayerHealth.GetComponent<Target>().health + "\n" + "Damage : " + wand.GetComponent<GunController>().damage;
	}
}
