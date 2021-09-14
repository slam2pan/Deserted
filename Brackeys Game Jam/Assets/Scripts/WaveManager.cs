using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private Spawner spawner;

    private int _wave;
    private int _waveDifficulty;
    private bool _waitingToSpawn;

    private float _searchCountdown = 1f;

    public static WaveManager instance;

    private void Awake()
    {
        spawner.onWaveFinishedCallback += FinishWave;

        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    void Start()
    {
        _wave = 0;
        _waitingToSpawn = true;
    }

    void Update()
    {
        if (_waitingToSpawn && !EnemyIsAlive())
        {
            ChangeWaveDifficulty(++_wave);
            print("starting wave " + _wave + " with difficulty " + _waveDifficulty);

            _waitingToSpawn = false;
            StartCoroutine(spawner.SpawnWave(_waveDifficulty));
        }
    }

    private void FinishWave()
    {
        _waitingToSpawn = true;
    }

    private void ChangeWaveDifficulty(int wave)
    {
        _waveDifficulty = (int) Mathf.Pow(wave, 2);
    }

    private bool EnemyIsAlive()
    {
        _searchCountdown -= Time.deltaTime;
        if (_searchCountdown <= 0f)
        {
            _searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
                return false;
        }

        return true;
    }

    public int GetWaveNum()
    {
        return _wave;
    }

    void OnDestroy()
    {
        spawner.onWaveFinishedCallback -= FinishWave;
    }
}
