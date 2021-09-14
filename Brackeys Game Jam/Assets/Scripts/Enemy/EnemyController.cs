using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyStats enemyStats;
    [SerializeField] private Transform enemyAimTransform;

    private bool coolingDown = false;
    private float timer = 0;

    private Rigidbody2D _rb;
    private Animator animator;
    private EnemyMove enemyMove;
    private int LayerMask = ~(1 << 8 | 1 << 9);

    bool TargetWithinRange(Collider2D target) => Vector2.Distance(transform.position, target.ClosestPoint(transform.position)) < enemyStats.AttackRange;

    void Awake()
    {
        animator = GetComponent<Animator>();
        enemyMove = new EnemyMove(GetComponent<Rigidbody2D>(), enemyAimTransform, enemyStats.MoveSpeed, animator);
    }

    void FixedUpdate()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, enemyStats.DetectRadius, LayerMask);
        if (hits.Length >= 1)
        {
            Collider2D target = ClosestTarget(hits);
            if (TargetWithinRange(target))
                Attack(target.gameObject);
            else
                enemyMove.MoveTowards(target.transform.position);
        }
        else
            enemyMove.MoveTowards(Vector3.zero);
    }

    private void Attack(GameObject target)
    {
        IDamageable currTarget = target.GetComponent<IDamageable>();
        if (currTarget == null)
            return;

        if (timer > enemyStats.AttackCooldown)
        {
            coolingDown = false;
            timer = 0;
        }

        if (coolingDown)
            timer += Time.deltaTime;
        else
        {
            PushBackPlayer(target);
            currTarget.TakeDamage(enemyStats.DamageAmount);
            coolingDown = true;
            timer = 0;
        }

    }

    private void PushBackPlayer(GameObject target)
    {
        PlayerController playerController = target.GetComponent<PlayerController>();
        if (playerController == null)
            return;
        playerController.PushBack(enemyStats.KnockbackAmount, enemyAimTransform.up);
    }

    private Collider2D ClosestTarget(Collider2D[] hits)
    {
        float shortestDist = Mathf.Infinity;
        int closestObjIndex = 0;

        for (int i = 0; i < hits.Length; i++)
        {
            float currDist = Vector2.Distance(transform.position, hits[i].transform.position);
            if (currDist < shortestDist)
            {
                closestObjIndex = i;
                shortestDist = currDist;
            }
        }
        return hits[closestObjIndex];
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, enemyStats.AttackRange);
    }
}
