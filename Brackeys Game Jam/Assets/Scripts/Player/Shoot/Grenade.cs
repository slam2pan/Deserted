using System.Collections;
using UnityEngine;

public class Grenade : Inflictor
{
    [SerializeField] private ParticleSystem grenadeExplode;

    public const float CookTime = 1.7f;
    public const float radius = 1.25f;

    void Start()
    {
        StartCoroutine(CookGrenade());
    }

    private IEnumerator CookGrenade()
    {
        yield return new WaitForSeconds(CookTime);

        ExplodeGrenade();

        yield break;
    }

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
