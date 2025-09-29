using System;
using UnityEngine;

public interface Iplayermovment
{
    void OnJump(UnityEngine.InputSystem.InputAction.CallbackContext context);
    void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context);
}

public class playermovment : MonoBehaviour, Iplayermovment
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            canJump = true;
        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            canJump = false;
        }
    }

    private Rigidbody2D rb;
    public float speed = 5f;
    public float jumphight = 10f;
    private Vector2 moveinput;
    private bool canJump;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() => rb.linearVelocityX = moveinput.x * speed;

    public void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        moveinput = context.ReadValue<Vector2>();
    }
    public void OnJump(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.performed && canJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumphight);

        }
    }
}
