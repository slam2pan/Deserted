using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Health _health;
    private Slider _healthSlider;

    void Awake()
    {
        _health = GetComponent<Health>();
        _healthSlider = GetComponentInChildren<Slider>();
    }

    void Start()
    {
        _healthSlider.maxValue = _health.GetHealth();
        _healthSlider.value = _health.GetHealth();
        _healthSlider.gameObject.SetActive(false);
    }

    void Update()
    {
        _healthSlider.value = _health.GetHealth();
        if (_health.GetHealth() < _healthSlider.maxValue)
            _healthSlider.gameObject.SetActive(true);
    }
}
