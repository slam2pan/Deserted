using UnityEngine;

public class Inflictor : MonoBehaviour
{
    public int damage;
    public const int UntargetableLayer = 9;

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}