using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Wave
{
    public string waveName;
    public int nomOfEnemies;
    public GameObject[] Enemies;
    public float spawnIntervalTime;

}

public class WaveSpawner : MonoBehaviour
{
    //public Transform enemyPrefab[];
    public Wave[] waves;
    public Transform spawnPoint;

    private Wave currentWave;
    private int curWaveNum;

    private bool canSpawn = true;
    private float nextSpawnTime;

    private bool waveButtonClick = false;
    public Text completeText;
    public float showTime;

    public string SceneWin;

    private void Start()
    {
        
    }

    private void Update()
    {
        
        if (waveButtonClick == true && curWaveNum != waves.Length)
        {
            currentWave = waves[curWaveNum];
            SpawnWave();
            GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (totalEnemies.Length == 0 && !canSpawn)
            {
                completeText.text = "Complete " + waves[curWaveNum].waveName;
                completeText.gameObject.SetActive(true);
                curWaveNum++;
                canSpawn = true;
                waveButtonClick = false;


            }
        }
        else if (curWaveNum >= waves.Length)
        {
            SceneManager.LoadScene(SceneWin);
            Debug.Log("You win");
        }
        
    }

    void SpawnWave()
    {
        completeText.gameObject.SetActive(false);
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.Enemies[Random.Range(0, currentWave.Enemies.Length)];
            Transform startPoint = spawnPoint;
            Instantiate(randomEnemy, startPoint.position, Quaternion.identity);
            currentWave.nomOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnIntervalTime;
            if (currentWave.nomOfEnemies == 0)
            {
                canSpawn = false;
                
                //TextShow();
            }
        }
        
    }

    public void WaveButton()
    {
        waveButtonClick = true;
    }

  
}
