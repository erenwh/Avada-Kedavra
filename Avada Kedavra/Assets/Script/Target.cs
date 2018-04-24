using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public bool canTP = true;

    public float health = 100;
    public bool dead = false;
	public bool isPlayer = false;
    public GameObject scoreManager;
    public bool isGoal = false;
    public GameObject bitch;
    public bool isEnemy = false;

    void Start()
    {
       scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Bullet") == true && isEnemy == true)
        {
            Debug.Log("collision entered");
            TakeDamage(GameObject.FindGameObjectWithTag("Wizard").GetComponent<GunController>().damage);

            Destroy(c.gameObject);
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Bullet") == true && isEnemy == true)
        {
            Debug.Log("FUCKING HIT");
            TakeDamage(30);

            Destroy(c.gameObject);
        }
        else if (isGoal == true)
        {
            //Debug.Log("slashed");
            TakeDamage(1);
            Destroy(c.gameObject);
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
            }
        }
	}
}
