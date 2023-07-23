using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
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

        waveCountdownText.text = "Next wave: " + Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave () // IENumerator ��������� ��������� ��� �� ����� ��� ����������
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1.5f); // �������� �� ������� ��� ���������� ����
        }
    }

    void SpawnEnemy ()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
