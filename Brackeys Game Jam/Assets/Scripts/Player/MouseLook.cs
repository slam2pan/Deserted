using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform playerAimTransform;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        TurnPlayer();
    }

    private void TurnPlayer()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerAimTransform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        animator.SetFloat("ZRotation", playerAimTransform.eulerAngles.z);
    }
}
