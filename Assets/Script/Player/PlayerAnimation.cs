using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{

    public Animator animator;
    public PlayerMovement playerMovement;
    private int facingDirection = 1;
        
    void Update()
    {
        float xVelocity = playerMovement.rb.linearVelocity.x;

        if(xVelocity > 0)
        {
            animator.SetBool("isrunning",true);
        }
        else
        {
            animator.SetBool("isrunning", false);
        }


        if ((xVelocity > 0 && facingDirection < 0) ||
            (xVelocity < 0 && facingDirection > 0))
        {
            Flip();
        }
    }
    void Flip()
    {
        facingDirection *= -1;

        Vector3 scale = transform.localScale;
    }
}
