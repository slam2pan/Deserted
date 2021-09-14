using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private Animator camAnim;

    void Awake()
    {
        camAnim = GetComponent<Animator>();
    }

    public void CamShake()
    {
        camAnim.SetTrigger("Shake");
    }
}
