using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    #region Singleton
    public static ParticleManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    #endregion
    
    public void PlayParticleEffect(ParticleSystem particleSystem, Vector3 position, Quaternion rotation)
    {
        ParticleSystem explosion = Instantiate(particleSystem, position, rotation);
        Destroy(explosion.gameObject, particleSystem.main.startLifetime.constant);
    }
}
