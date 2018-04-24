using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public float health = 100;
    public bool dead = false;
	public bool isPlayer = false;
    public GameObject scoreManager;
    public bool isGoal = false;
    public bool isEnemy = false;

    void Start()
    {
       scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name == "Bullet" && isEnemy == true)
        {
            Debug.Log("hit");
            Destroy(coll.gameObject);
            TakeDamage(GameObject.FindGameObjectWithTag("Wizard").GetComponent<GunController>().damage);
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if (isGoal == true)
        {
            Debug.Log("slashed");
            TakeDamage(5);
        }
    }

    // Update is called once per frame
    void Update () {
        if (health <= 0) dead = true;
        if (dead == true)
        {
			if (isEnemy == true) {
				scoreManager.GetComponent<Score>().addScore(10);
				Destroy(gameObject);
			}
            else if (isGoal == true)
            {
                scoreManager.GetComponent<Score>().subScore(50);
                Destroy(gameObject);
            }
        }
	}
}
