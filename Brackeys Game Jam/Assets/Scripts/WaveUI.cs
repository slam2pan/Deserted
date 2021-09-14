using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    [SerializeField] private WaveManager _waveManager;
    private Text _waveText;

    void Start()
    {
        _waveText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _waveText.text = "Wave: " + _waveManager.GetWaveNum();
    }
}
