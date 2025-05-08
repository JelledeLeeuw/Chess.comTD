using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] checkers;
    [SerializeField] private int[] waves;
    [SerializeField] private Vector3 spawnpoint;
    private int _waveCount;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        for (int i = 0; i < _waveCount + 3; i++)
        {
            Instantiate(checkers[waves[i]],spawnpoint,Quaternion.identity);
            yield return new WaitForSeconds(0.9f);
        }
        _waveCount++;
        yield return new WaitForSeconds(5);
        StartCoroutine(SpawnWaves());
    }
}
