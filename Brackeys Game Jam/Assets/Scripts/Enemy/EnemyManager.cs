using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem explodeEffect;
    [SerializeField] private ScreenShake screenShake;
    
    private ShopManager shopManager;
    public GameObject[] guns;
    public const int DropRate = 20;

    public static EnemyManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        shopManager = GetComponent<ShopManager>();
    }


    public void KillEnemy(Vector3 position, Quaternion rotation, int spaceRice)
    {
        screenShake.CamShake();
        ParticleManager.instance.PlayParticleEffect(explodeEffect, position, rotation);
        AudioManager.instance.Play("EnemyDead");
        shopManager.AddToBalance(spaceRice);
        
        if (Random.Range(0, 100) < DropRate)
        {
            int randomGun = Random.Range(0, guns.Length);
            Instantiate(guns[randomGun], position, rotation);
        }
    }
}