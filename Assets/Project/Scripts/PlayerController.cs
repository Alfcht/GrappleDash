using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(InputReader))]
public class PlayerController : MonoBehaviour
{
    [Header("Run")]
    [SerializeField] float maxSpeed = 9f;
    [SerializeField] float acceleration = 90f;
    [SerializeField] float deceleration = 70f;

    Rigidbody2D rb;
    InputReader input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<InputReader>();
    }

    void FixedUpdate()
    {
        float x = input.Move.x;
        float target = x * maxSpeed;
        float rate = Mathf.Abs(x) > 0.01f ? acceleration : deceleration;
        float vx = Mathf.MoveTowards(rb.linearVelocity.x, target, rate * Time.fixedDeltaTime);
        rb.linearVelocity = new Vector2(vx, rb.linearVelocity.y);
    }
}
