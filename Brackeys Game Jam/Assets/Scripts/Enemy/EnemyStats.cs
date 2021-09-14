using UnityEngine;

[CreateAssetMenu(menuName = "Assets/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    [Range(0, 30)]
    public float DetectRadius = 3f;

    [Range(0, 30)]
    public float AttackRange = 1f;

    [Range(0, 30)]
    public float AttackCooldown = 2f;

    [Range(0, 100)]
    public int DamageAmount = 2;

    [Range(0, 100)]
    public float KnockbackAmount = 5f;
    
    [Range(0, 10)]
    public float MoveSpeed = 1f;
}
