using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Gun currGun;
    [SerializeField] private SpriteRenderer currGunImage;
    [SerializeField] private Gun starterPistol;

    private Shooter shooter;
    private int _ammo;
    private AmmoUI _ammoUI;

    void Awake()
    {
        shooter = GetComponent<Shooter>();
        _ammoUI = GameObject.Find("AmmoUI").GetComponent<AmmoUI>();
    }

    void Start()
    {
        currGun = starterPistol;
        _ammo = starterPistol.Ammo;
    }

    void Update()
    {
        if (_ammo <= 0)
            ChangeGun(starterPistol);

        if (currGun.Automatic && Input.GetMouseButton(0))
            StartCoroutine(shooter.Shoot(currGun));
        else if (!currGun.Automatic && Input.GetMouseButtonDown(0))
            StartCoroutine(shooter.Shoot(currGun));
    }

    public void ChangeGun(Gun gun)
    {
        currGun = gun;
        currGunImage.sprite = gun.gunImage;

        _ammo = gun.Ammo;
        SetAmmoText();
        shooter.readyToShoot = true;
    }

    public void SubtractAmmo(int amount)
    {
        _ammo -= amount;
        SetAmmoText();
    }

    private void SetAmmoText()
    {
        string ammoAmount = currGun.Equals(starterPistol) ? "Infinite" : _ammo.ToString();
        _ammoUI.AmmoAmount(ammoAmount);
    }
}
