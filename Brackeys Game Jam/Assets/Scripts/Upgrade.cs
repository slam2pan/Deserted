using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    private int cost = 20;
    [SerializeField] private Gun gun;
    [SerializeField] private Text costText;

    void Start()
    {
        costText.text = "Cost: " + cost;
    }

    public void UpgradeCooldown()
    {
        if (ShopManager.instance.GetBalance() >= cost)
            ShopManager.instance.AddToBalance(-cost);
        else
            return;
        
        cost *= 2;
        costText.text = "Cost: " + cost;
        UpgradeManager.instance.UpgradeGun(gun);
    }
}
