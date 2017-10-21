using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { Spawning, Waiting, Counting};


    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform Enemy;
        public int Count;
        public float SpawnRate;

    }

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    [SerializeField] private float waveCountdown;

    private float searchCountdown = 1;

    private SpawnState spawnState = SpawnState.Counting;


    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
        if (spawnState == SpawnState.Waiting)
        {
            //check for enemies
            if (!EnemyIsAlive())
            {


                Debug.Log("Wave Completed");
                 //Begins a new round
            }
            else
            {
                return;
            }
        }


        if (waveCountdown <= 0)
        {
            if (spawnState != SpawnState.Spawning)
            {
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
        if (searchCountdown <= 0)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        spawnState = SpawnState.Spawning;
        
         for (int i = 0; i < _wave.Count; i++)
        {
            SpawnEnemy(_wave.Enemy); // check enemy if this dont work
            yield return new WaitForSeconds(1 / _wave.SpawnRate);

        }
            //spawn 
        
        spawnState = SpawnState.Waiting;

        yield break;

    }

    void SpawnEnemy (Transform _enemy)
    {
        Instantiate(_enemy, transform.position, transform.rotation);

        // Spawn enemy
        Debug.Log("Spawning Enemy: " + _enemy.name);
    }




}
