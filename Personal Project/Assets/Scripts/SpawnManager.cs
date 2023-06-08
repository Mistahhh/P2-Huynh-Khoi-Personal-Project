using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject gameManagerComponent;
    
    public float delay = 2;
    float timer;

    public TextMeshProUGUI waveText;
    public int wavetracker;

    public GameObject enemyPrefab;
    public GameObject enemytwoPrefab;
    public GameObject healthPrefab;
    private float spawnRange = 20.0f;
    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        wavetracker = 1;
        waveText.text = "Wave: " + wavetracker;

        SpawnEnemyWave(waveNumber);
        Instantiate(healthPrefab, GenerateSpawnPosition(), healthPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    
        if(enemyCount == 0)
        {
            timer += Time.deltaTime;

            if (timer > delay)
            {
                waveNumber++;
                SpawnEnemyWave(waveNumber);
                Instantiate(healthPrefab, GenerateSpawnPosition(), healthPrefab.transform.rotation);
                UpdateWave(1);
                timer -= delay;
            }
        }
    
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation); 
        }

        if(waveNumber > 4)
        {
            for (int i = 4; i < enemiesToSpawn; i++)
            {
                Instantiate(enemytwoPrefab, GenerateSpawnPosition(), enemytwoPrefab.transform.rotation);
            }
        }
    }


    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 1, spawnPosZ);

        return randomPos;
    }

    void UpdateWave(int waveToAdd)
    {
        wavetracker += waveToAdd;
        waveText.text = "Wave: " + wavetracker;
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(7);
    }
}