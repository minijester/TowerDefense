using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public GameObject enemy;
    public Transform spawnPoint;
    public float timeBetweenWaves = 10f;
    private float countdown = 2f;
    private int waveIndex;
    private float timeWaingForEachEnemy = 0.5f;
    public Text countdownText;

    private void Start()
    {
        waveIndex = 1;
    }

    private void Update()
    {

        
        if (GameManager.gameEnded)
        {
            this.enabled = false;
            return;
        }
        

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        countdownText.text = string.Format("{0:00.0}", countdown);
    }

    IEnumerator SpawnWave() // can wait when using IEnumberator
    {
        PlayerStat.round++;
        for (int i=0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeWaingForEachEnemy);
        }
        waveIndex++;
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemy, spawnPoint.position,spawnPoint.rotation);
    }
}
