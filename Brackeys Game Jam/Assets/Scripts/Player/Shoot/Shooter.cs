using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform firePoint;

    public bool readyToShoot = true;
    private float cooldown;
    private Player player;

    void Awake()
    {
        player = GetComponent<Player>();
    }

    public IEnumerator Shoot(Gun gun)
    {
        if (readyToShoot)
        {
            readyToShoot = false;
            PlayerController playerController = this.gameObject.GetComponent<PlayerController>();

            for (int i = 0; i < gun.ShotAngles.Length; i++)
            {
                GameObject bullet = Instantiate(gun.bullet, firePoint.position,
                    Quaternion.Euler(firePoint.eulerAngles + new Vector3(0, 0, gun.ShotAngles[i])));

                if (gun.shoot != null)
                    AudioManager.instance.Play(gun.shoot);

                Inflictor inflictor = bullet.GetComponent<Inflictor>();
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                inflictor.damage = gun.Damage;
                rb.AddForce(rb.transform.up * gun.Velocity, ForceMode2D.Impulse);
                playerController.PushBack(gun.Recoil, -firePoint.up);
                yield return new WaitForSeconds(gun.ShotDelay);
            }

            player.SubtractAmmo(gun.ShotAngles.Length);

            if (gun.reload != null)
                    AudioManager.instance.Play(gun.reload);
            yield return new WaitForSeconds(UpgradeManager.instance.gunCooldowns[gun]);

            readyToShoot = true;
        }

        yield break;
    }
}
