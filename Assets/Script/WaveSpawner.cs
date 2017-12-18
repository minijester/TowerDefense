using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemy;
    public Transform spawnPoint;
    public float timeBetweenWaves = 10f;
    private float countdown = 2f;
    private int waveIndex = 1;
    private float timeWaingForEachEnemy = 0.5f;
    public Text countdownText;

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
        waveIndex++;
        PlayerStat.round++;
        for (int i=0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeWaingForEachEnemy);
        }
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemy, spawnPoint.position,spawnPoint.rotation);
    }
}
