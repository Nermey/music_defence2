using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 10f;
    private float countdown = 2f; // время до начала первой волны (позже время между волнами (счетчик))
    private int waveIndex = 0;

    public Text waveCountdownText;

    void Update ()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime; // счетчик уменьшается каждые 2f (2с) на 1

        waveCountdownText.text = "Next wave: " + Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave () // IENumerator позволяет поставить код на паузу при выполнении
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1.5f); // задержка по времени при выполнении кода
        }
    }

    void SpawnEnemy ()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
