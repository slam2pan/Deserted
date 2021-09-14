using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _base;
    [SerializeField] private GameObject _playerPrefab;

    public const float RespawnTimer = 5f;
    private float timer = 0f;
    private Player _player;

    void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (_base == null)
            EndGame();
        if (_player == null)
            RespawnPlayer();
    }

    private void RespawnPlayer()
    {
        timer += Time.deltaTime;

        if (timer > RespawnTimer)
        {
            _player = Instantiate(_playerPrefab).GetComponent<Player>();
            timer = 0;
        }
    }

    private void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
