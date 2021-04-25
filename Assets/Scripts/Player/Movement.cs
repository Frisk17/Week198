using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    #pragma warning disable IDE0044 // Add readonly modifier
    private float movementMultiplier;
    #pragma warning restore IDE0044 // Add readonly modifier

    private const float slowdownModifier = 1.25f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Get the input
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        Vector2 input = new Vector2(hor, ver);

        //Add force to make the player move
        rb.AddForce(input * movementMultiplier);

        //Normalise the player speed accordingly
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, GameHandler.Instance.playerSpeed);

        //Check if the player is not movng in the direction of input and hinder the movement if so
        if (Math.Sign(input.x) != Math.Sign(rb.velocity.x))
        {
            rb.velocity = new Vector2(rb.velocity.x / slowdownModifier, rb.velocity.y);
        }

        if (Math.Sign(input.y) != Math.Sign(rb.velocity.y))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / slowdownModifier);
        }
    }
}
