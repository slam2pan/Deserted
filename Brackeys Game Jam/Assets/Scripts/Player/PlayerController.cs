using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public const float MoveSpeed = 1f;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(horizontalInput, verticalInput, 0);

        _rb.AddForce(input * MoveSpeed, ForceMode2D.Impulse);
    }

    public void PushBack(float amount, Vector3 direction)
    {
        _rb.AddForce(direction * amount, ForceMode2D.Impulse);
    }
}
