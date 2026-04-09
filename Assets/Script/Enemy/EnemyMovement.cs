using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 2f;
    public Transform checkWallPos;
    public Vector2 checkWallSize = new(0.5f, 0.5f);
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool facingRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Tentukan arah awal secara random
        facingRight = Random.value > 0.5f;
        transform.localScale = new Vector3(facingRight ? 1 : -1, 1, 1);
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        // Selalu bergerak sesuai arah saat ini
        float moveDir = facingRight ? 1f : -1f;
        rb.linearVelocity = new Vector2(moveDir * speed, rb.linearVelocity.y);

        // Jika ada collision di depan, balik arah
        if (CollideInFacingDirection())
        {
            facingRight = !facingRight;
            transform.localScale = new Vector3(facingRight ? 1 : -1, 1, 1);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 offset = facingRight ? Vector3.right : Vector3.left;
        Gizmos.DrawCube(checkWallPos.position + offset, checkWallSize);
    }

    private bool CollideInFacingDirection()
    {
        Vector3 offset = facingRight ? Vector3.right : Vector3.left;
        return Physics2D.OverlapBox(checkWallPos.position + offset, checkWallSize, 0, groundLayer);
    }

    // Tambahan: Enemy hancur jika ditabrak player dari atas
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Cek arah tabrakan: normal.y < 0 berarti player datang dari atas
            if (collision.contacts[0].normal.y < 0)
            {
                // Opsional: buat player memantul ke atas
                Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (playerRb != null)           
                {
                    playerRb.AddForce(Vector2.up * 300f);
                }

                // Hancurkan enemy
                Destroy(gameObject);
            }
        }
    }
}
