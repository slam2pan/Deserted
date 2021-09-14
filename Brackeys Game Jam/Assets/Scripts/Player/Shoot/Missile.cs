using System.Collections;
using UnityEngine;

public class Missile : Inflictor
{
    [SerializeField] private ParticleSystem grenadeExplode;

    public const float radius = 2.3f;

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        // initial impact damage
        if (collisionInfo.gameObject.layer == UntargetableLayer)
            return;

        IDamageable damageable = collisionInfo.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
            damageable.TakeDamage(damage / 2);

        ExplodeGrenade();

        Destroy(this.gameObject);
    }

    // splash damage
    private void ExplodeGrenade()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.layer == UntargetableLayer)
                continue;
            IDamageable damageable = collider.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
                damageable.TakeDamage(damage);
        }

        ParticleManager.instance.PlayParticleEffect(grenadeExplode, transform.position, transform.rotation);
        AudioManager.instance.Play("Explosion");
        Destroy(this.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
