using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public Transform[] enemyPrefab;
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

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        if (!GameManager.gameIsOver)
        { 
            if (Mathf.Round(countdown) <= 10f)
            {
                waveCountdownText.text = "Next wave: " + string.Format("{0:00.00}", countdown);
            }
            else
            {
                waveCountdownText.text = "";
            }
        }
        else
        {
            waveCountdownText.text = "";     
        }
    }

    IEnumerator SpawnWave () // IENumerator позволяет поставить код на паузу при выполнении
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            if (GameManager.gameIsOver)
            {
                break;
            }
            SpawnEnemy();
            yield return new WaitForSeconds(1.5f); // задержка по времени при выполнении кода
        }
    }

    void SpawnEnemy ()
    {
        Instantiate(enemyPrefab[0], spawnPoint.position, spawnPoint.rotation); // пока только спавн рэпера
    }
}
