using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Gun gun;

    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player == null)
            return;
        
        player.ChangeGun(gun);

        Destroy(this.gameObject);
    }

}
