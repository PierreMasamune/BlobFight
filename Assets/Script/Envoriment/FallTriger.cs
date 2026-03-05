using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FallTriger: MonoBehaviour
{

    private RespawnData respawnData;
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            if (player != null)
            {
               
                Debug.Log("Player respawned at checkpoint!");
            }
        }
    }

}
