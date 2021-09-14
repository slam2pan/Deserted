using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefabs;

    private float _spawnDelay = 1f;
    private Dictionary<int, Enemy> enemies = new Dictionary<int, Enemy>();

    public delegate void onWaveFinished();
    public onWaveFinished onWaveFinishedCallback;

    void Start()
    {
        for (int i = 0; i < _enemyPrefabs.Length; i++)
        {
            enemies.Add(i, _enemyPrefabs[i].GetComponent<Enemy>());
        }
    }

    public IEnumerator SpawnWave(int enemyPoints)
    {
        while (enemyPoints > 0)
        {
            // pick enemy to spawn
            int enemyToSpawn = Random.Range(0, _enemyPrefabs.Length);
            while (enemyPoints < enemies[enemyToSpawn].PointValue)
            {
                if (enemyToSpawn < 0)
                    throw new System.Exception("spawning fucked up");
                enemyToSpawn--;
            }

            SpawnEnemy(enemyToSpawn);
            enemyPoints -= enemies[enemyToSpawn].PointValue;
            yield return new WaitForSeconds(_spawnDelay);
        }

        onWaveFinishedCallback.Invoke();
        yield break;
    }

    public void SpawnEnemy(int enemyNum)
    {
        float direction = (int)Random.Range(0, 4);
        Vector3 enemyPos = Vector3.zero;

        switch (direction)
        {
            case 0:
                enemyPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Random.Range(0, Screen.height), 0));
                break;
            case 1:
                enemyPos = Camera.main.ScreenToWorldPoint(new Vector3(0, Random.Range(0, Screen.height), 0));
                break;
            case 2:
                enemyPos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Screen.height, 0));
                break;
            case 3:
                enemyPos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), 0, 0));
                break;
        }

        Instantiate(_enemyPrefabs[enemyNum], new Vector3(enemyPos.x, enemyPos.y, 0), _enemyPrefabs[enemyNum].transform.rotation, this.transform);
    }
}
