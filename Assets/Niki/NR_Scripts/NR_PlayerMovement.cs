using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;

    private CharacterController characterController;

    private Transform cameraTransform;

    public Rigidbody rb;

    private NR_PlayerStats playerStats;

    public float groundDistance = 0.4f;

    public LayerMask groundLayer;

    public Transform groundCheck;

    private Vector3 velocity;

    private bool isGrounded;

    private float gravity = -50f; // saatat joutua t‰t‰ s‰‰t‰m‰‰n fysiikan simuloimiseksi

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
        playerStats = GetComponent<NR_PlayerStats>();

        rb = GetComponent<Rigidbody>();

        if (groundCheck == null)
        {
            Debug.LogError("Assign a GroundCheck object to the PlayerMovement script in the inspector.");
            this.enabled = false;
            return;
        }
    }

    private void Update()
    {
        if (playerStats.dead == false)
        {
            MovePlayer();
        }

        
    }

    private void MovePlayer()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // pid‰ hahmo maassa
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forwardDirection = cameraTransform.forward;
        Vector3 rightDirection = cameraTransform.right;

        forwardDirection.y = 0; // niin ettei pelaaja l‰hde lent‰m‰‰n y akselilla.
        rightDirection.y = 0;

        forwardDirection.Normalize();
        rightDirection.Normalize();

        Vector3 desiredDirection = (forwardDirection * vertical + rightDirection * horizontal).normalized;
        Vector3 movement = desiredDirection * speed * Time.deltaTime;

        characterController.Move(movement);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}