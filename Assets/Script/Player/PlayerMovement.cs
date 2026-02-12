using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float jumpPower = 10f;
    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.5f);
    public LayerMask groundLayer;
    private float horizontalInput;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
    }


    public void Move(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>().x;   
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (Isgrounded())   
        {
            if (context.performed)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            }
            else if (context.canceled)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(groundCheckPos.position,groundCheckSize);
    }
    // Update is called once per frame

    private bool Isgrounded()
    {
        if(Physics2D.OverlapBox(groundCheckPos.position,groundCheckSize,0,groundLayer)) {
            return true;
        }
        return false;

    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * playerSpeed,rb.linearVelocity.y);
    }

   

}
