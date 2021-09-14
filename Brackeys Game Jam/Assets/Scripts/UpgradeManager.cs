using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public Dictionary<Gun, float> gunCooldowns = new Dictionary<Gun, float>();
    public Gun[] guns;

    public const float CooldownPercentDecrease = 0.9f;

    public static UpgradeManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    void Start()
    {
        foreach (Gun gun in guns)
        {
            gunCooldowns.Add(gun, gun.Cooldown);
        }
    }

    public void UpgradeGun(Gun gun)
    {
        if (!gunCooldowns.ContainsKey(gun))
            return;
        gunCooldowns[gun] *= CooldownPercentDecrease;
        print(gun + " cooldown has been reduced to " + gunCooldowns[gun]);
    }
}
