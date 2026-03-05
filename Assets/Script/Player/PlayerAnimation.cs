using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{

    public Animator animator;
    public PlayerMovement playerMovement;
    private SpriteRenderer spriteRenderer;

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


        if (xVelocity> 0)
            spriteRenderer.flipX = false;
        else if (xVelocity < 0)
            spriteRenderer.flipX = true;
    }

}
