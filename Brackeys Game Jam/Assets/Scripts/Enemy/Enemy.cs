using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(0, 1000)]
    public int PointValue = 0;

    [Range(1, 100)]
    [SerializeField] private int SpaceRice = 1;

    private bool isQuitting = false;

    void OnApplicationQuit()
    {
        isQuitting = true;
    }

    void OnDestroy()
    {
        if (!isQuitting)
        {
            EnemyManager.instance.KillEnemy(transform.position, transform.rotation, SpaceRice);
        }
    }

}
