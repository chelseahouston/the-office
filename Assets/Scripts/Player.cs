using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;
    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    public Animator animator;
    public StopStartPlayerMovement playerMovement;

    private void Awake()
    {
        // Ensure there is only one instance of the Player object
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.moving)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            Vector2 movement = new Vector2(horizontalInput, verticalInput);
            movement.Normalize();

            rb.velocity = movement * moveSpeed;

            animator.SetFloat("Vertical", verticalInput);
            animator.SetFloat("Horizontal", horizontalInput);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }
}
