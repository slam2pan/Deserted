using UnityEngine;

public class Bullet : Inflictor
{
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.layer == UntargetableLayer)
            return;

        if (collisionInfo.gameObject.CompareTag("Enemy"))
        {
            IDamageable damageable = collisionInfo.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
                damageable.TakeDamage(damage);
        }

        Destroy(this.gameObject);
    }
}
