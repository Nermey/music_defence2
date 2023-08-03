using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public Transform[] enemyPrefab;
    public Transform spawnPoint;


    public float timeBetweenWaves = 10f;
    private float countdown = 2f; // ����� �� ������ ������ ����� (����� ����� ����� ������� (�������))
    private int waveIndex = 0;

    public Text waveCountdownText;

    void Update ()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime; // ������� ����������� ������ 2f (2�) �� 1

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

    IEnumerator SpawnWave () // IENumerator ��������� ��������� ��� �� ����� ��� ����������
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            if (GameManager.gameIsOver)
            {
                break;
            }
            SpawnEnemy();
            yield return new WaitForSeconds(1.5f); // �������� �� ������� ��� ���������� ����
        }
    }

    void SpawnEnemy ()
    {
        Instantiate(enemyPrefab[0], spawnPoint.position, spawnPoint.rotation); // ���� ������ ����� ������
    }
}
