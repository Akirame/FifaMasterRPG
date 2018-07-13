using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [System.Serializable]
    public class EnemyList
    {
        public List<Enemy> enemies;
    }
    public List<EnemyList> EnemyWaves;
    public Transform[] spawnPoints;

	public Transform lootDropPoint;
	public List<GameObject> itemsList;

	private GameObject wave;
    private int currentWave;
    private int currentEnemies;
    private float timeBetweenWaves;
    private float timer;
	private bool nextWave;
	public bool levelWin;

	private void Start()
    {
        Enemy.Hitted += EnemyKilled;
        nextWave = true;
        currentWave = 1;
        wave = new GameObject();
        timeBetweenWaves = 3;
        timer = 0;
        currentEnemies = 0;
		levelWin = false;
    }

    private void Update()
    {
		if (!levelWin)
		{
			if (currentWave <= EnemyWaves.Count)
			{
				if (nextWave)
				{
					SpawnWave();
					nextWave = false;
				}
				if (currentEnemies <= 0) //si toda la oleada es eliminada
				{
					Debug.Log("WAVE END");
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
			{
				levelWin = true;

				int randomItem = Random.Range(0, itemsList.Count);
				Instantiate(itemsList[randomItem], lootDropPoint.position, Quaternion.identity);
				// Do other stuff when player wins
			}
		}
	}
    private void SpawnWave()
    {
        wave.name = "Wave " + currentWave;
        for (int i = 0; i < EnemyWaves[currentWave - 1].enemies.Count; i++)
        {
            Enemy e = EnemyWaves[currentWave - 1].enemies[i];
            Transform t = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(e.transform.gameObject, t.position, Quaternion.identity, wave.transform);
        }
        currentEnemies = EnemyWaves[currentWave - 1].enemies.Count;
    }
    private void EnemyKilled(Enemy e)
    {
        currentEnemies--;
    }
}
