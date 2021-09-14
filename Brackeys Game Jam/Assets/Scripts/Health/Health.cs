using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IDamageable
{
    [Range(0, 1000)]
    [SerializeField] private int _health = 100;

    void Update()
    {
        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;
    }

    public int GetHealth()
    {
        return _health;
    }
    
}
