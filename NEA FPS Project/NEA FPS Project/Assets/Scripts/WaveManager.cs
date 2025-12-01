using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    public int baseEnemyCount = 3;
    public int timeBetweenWaves = 5;

    public int currentWave = 0;
    public bool waveInProgress = false;

    public UIManager uiManager;

    public int enemiesKilled = 0;



    void Start()
    {
        GameObject waypointCluster = GameObject.FindGameObjectWithTag("WayPoint");
        int count = waypointCluster.transform.childCount;
        spawnPoints = new Transform[count];

        for (int i = 0; i < count; i++)
        {
            spawnPoints[i] = waypointCluster.transform.GetChild(i);
        }

        StartCoroutine(StartNextWave());
    }

    // Update is called once per frame
    void Update()
    {
        if (waveInProgress == true)
        {
            int enemiesRemaining = GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (enemiesRemaining == 0)
            {
                waveInProgress = false;
                StartCoroutine(StartNextWave());
            }
        }
    }

    IEnumerator StartNextWave()
    {
        Debug.Log("Starting Wave " + (currentWave + 1));
        yield return new WaitForSeconds(timeBetweenWaves);

        currentWave++;

        uiManager.currentWave = currentWave;
        uiManager.UpdateWaveText(currentWave);


        int enemiesToSpawn = baseEnemyCount + (currentWave * 2);

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f); //1 second delay between spawns
        }

        waveInProgress = true;
    }

    void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
    }

    public void AddKill()
    {
        enemiesKilled++;
    }




}
