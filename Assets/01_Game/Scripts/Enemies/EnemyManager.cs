using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    [System.Serializable]
    public class EnemyList
    {
        public Enemy[] enemies;
    }
    public EnemyList[] EnemyWaves;
    public Transform[] spawnPoints;

    private bool nextWave;
    private int currentWave;
    private GameObject wave;
    private float timeBetweenWaves;
    private float timer;
    private void Start()
    {
        Enemy.Hitted += EnemyKilled;
        nextWave = true;
        currentWave = 1;
        wave = new GameObject();
        timeBetweenWaves = 3;
        timer = 0;
    }

    private void Update()
    {
        if (currentWave <= EnemyWaves.Length)
        {
            if (nextWave)
            {

                SpawnWave();
                nextWave = false;
            }
            if (EnemyWaves[currentWave - 1].enemies.Length <= 0) //si toda la oleada es eliminada
            {
                if (timer >= timeBetweenWaves)
                {
                    currentWave++;
                    nextWave = true;
                    timer = 0;
                }
                else
                    timer += Time.deltaTime;
            }
        }
        else
            Debug.Log("WIN");
    }
    private void SpawnWave()
    {                        
        wave.name = "Wave " + currentWave;
        for (int i = 0; i < EnemyWaves[currentWave - 1].enemies.Length; i++)
        {
            Enemy e = EnemyWaves[currentWave - 1].enemies[i];            
            Transform t = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(e.transform.gameObject, t.position, Quaternion.identity, wave.transform);
        }
    }
    private void EnemyKilled(Enemy e)
    {
        Debug.Log("Dead");
    }
}
