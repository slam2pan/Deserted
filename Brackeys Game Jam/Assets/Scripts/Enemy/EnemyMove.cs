using UnityEngine;

public class EnemyMove
{
    readonly float moveSpeed;
    readonly Rigidbody2D rb;
    readonly Transform transform;
    readonly Animator animator;

    public EnemyMove(Rigidbody2D rb, Transform transform, float moveSpeed, Animator animator)
    {
        this.rb = rb;
        this.transform = transform;
        this.moveSpeed = moveSpeed;
        this.animator = animator;
    }

    public void MoveTowards(Vector3 target)
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, target - transform.position);
        animator.SetFloat("ZRotation", transform.eulerAngles.z);
        rb.AddForce(transform.up * moveSpeed, ForceMode2D.Impulse);
    }
}
