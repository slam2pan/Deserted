using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    private Text _ammoText;

    void Awake()
    {
        _ammoText = GetComponent<Text>();
    }

    void Start()
    {
        _ammoText.text = "Ammo: Infinite";
    }

    public void AmmoAmount(string amount)
    {
        _ammoText.text = "Ammo: " + amount;
    }
}
