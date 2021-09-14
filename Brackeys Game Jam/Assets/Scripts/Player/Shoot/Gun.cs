using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Gun")]
public class Gun : ScriptableObject
{
    [Range(0, 10)]
    public float Cooldown;

    [Range(0, 100)]
    public float Velocity;

    [Range(0, 100)]
    public int Damage;

    [Range(-180, 180)]
    public float[] ShotAngles;

    [Range(0, 1)]
    public float ShotDelay;

    [Range(0, 100)]
    public float Recoil;

    [Range(0, 999999999)]
    public int Ammo;

    public bool Automatic = false;

    public GameObject bullet;
    public Sprite gunImage;

    [Header("Sounds")]
    [Tooltip("Enter name of clip")]
    public string shoot;
    
    [Tooltip("Enter name of clip")]
    public string reload;

}