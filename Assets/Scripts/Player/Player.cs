using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private static Player instance;
    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    public Animator animator;
    public StopStartPlayerMovement playerMovement;
    public Vector3 cubiclePosition, mainOfficePosition, hallwayPosition, conferenceRoomPosition, bathroomPosition, cafePosition, bossOfficePosition;
    public SpeechInteraction speechInteraction;
    public int interaction;

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
    private void Start()
    {
        SetStartingPositions();
        transform.position = cubiclePosition;
        interaction = 0;
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

        if (Input.GetKeyDown(KeyCode.E) && interaction!=0)
        {
            speechInteraction.Speech(interaction);
        }
    }

    public void setSpeechPanel()
    {
        speechInteraction = GameObject.Find("SpeechPanel").GetComponent<SpeechInteraction>();
    }

    public void SetStartingPositions()
    {
        // set starting positions depending on which building entered/exited
        cubiclePosition = new Vector3(4.17f, -0.83f, 0f);
        mainOfficePosition = new Vector3(-5.65f, -0.98f, 0f);
        hallwayPosition = new Vector3(-6.09f, -0.83f, 0f);
        conferenceRoomPosition = new Vector3(3.71f, -0.83f, 0f);
        bathroomPosition = new Vector3(-6.09f, -0.83f, 0f);
        cafePosition = new Vector3(-6.09f, -0.83f, 0f);
        bossOfficePosition = new Vector3(-4.09f, -0.83f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            switch (collision.name)
            {
                case "JohnDesk":
                interaction = 1;
                break;

                case "JaneDesk":
                interaction = 2;
                break;

                case "SamDesk":
                interaction = 3;
                break;

                case "EmilyDesk":
                interaction = 4;
                break;

                case "CharlieDesk":
                interaction = 5;
                break;
            }
        }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interaction = 0;
    }
}
