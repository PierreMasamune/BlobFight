using UnityEngine;


public class HitboxTake : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(transform.parent.gameObject);// hancurkan enemy

        }
    }
}
