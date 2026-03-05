using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    static float t = 0.0f;
    [Header("Movement Settings")]
    public float distance, speed;
    private float originalPos;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPos = transform.position.x;
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        t += Time.deltaTime * speed;
        var x = originalPos + Mathf.Sin(t) * distance;
        rb.linearVelocity = new Vector2(x, transform.position.y);
    }
}
