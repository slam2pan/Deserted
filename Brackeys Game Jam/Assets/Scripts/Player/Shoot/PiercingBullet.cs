using UnityEngine;

public class PiercingBullet : Inflictor
{
    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.layer == UntargetableLayer)
            return;

        if (collisionInfo.gameObject.CompareTag("Enemy"))
        {
            IDamageable damageable = collisionInfo.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
                damageable.TakeDamage(damage);
            
            return;
        }

        Destroy(this.gameObject);
    }
}
