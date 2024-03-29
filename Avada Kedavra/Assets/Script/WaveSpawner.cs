﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public GameObject bitch;
	public GameObject manager;

    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }
    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private SpawnState state = SpawnState.COUNTING;

    private float searchCountdown = 1f;

    // Use this for initialization
    void Start() {

        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced.");
        }
        waveCountdown = timeBetweenWaves;

    }

    // Update is called once per frame
    void Update() {

        if (state == SpawnState.WAITING)
        {
            // check if enemies are still alive
            if (!EnemyIsAlive())
            {
                //begin a new round
                WaveCompleted();
                
           
                 
            }
            else
            {
                return;
            }

        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                // start spawning wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave (Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        //spawn
        state = SpawnState.WAITING;


        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        // spawn enemy
        Debug.Log("Spawning Enemy: " + _enemy.name);
        
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
		manager.GetComponent<MenuManager>().enemyNum++;
       
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            // wave done
            if (bitch.GetComponent<Target>().canTP == true)
            {
                Debug.Log("tping");
                Debug.Log("Failed");
                bitch.transform.position = new Vector3(0f, 0f, 309f);
                bitch.GetComponent<Target>().canTP = false;
            }

            /*nextWave = 0;
            Debug.Log("All waves Complete! looping");*/
        }
        else
        {

            nextWave++;
        }
    }
}
