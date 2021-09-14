using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private Text balanceText;
    [SerializeField] private GameObject shop;
    private int _balance = 0;

    public static ShopManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    void Start()
    {
        shop.SetActive(false);
    }

    public int GetBalance()
    {
        return _balance;
    }

    public void AddToBalance(int amount)
    {
        _balance += amount;
    }

    void Update()
    {
        balanceText.text = "Balance: " + _balance;
    }

    public void OpenCloseShop()
    {
        if (shop.activeSelf)
        {
            shop.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            shop.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
