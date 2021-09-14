using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Wave : MonoBehaviour
{
    private int waveNum = 0;
    private Text endText;

    public static Wave instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        waveNum = WaveManager.instance.GetWaveNum();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 2)
        {
            endText = GameObject.Find("EndText").GetComponent<Text>();
            endText.text = "You survived " + waveNum + " waves";
        }
    }
}
