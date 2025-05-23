using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float walkSpeed = 5f;
    public float runSpeed = 7f;

    private CharacterController characterController;

    private Transform cameraTransform;

    private NR_PlayerStats playerStats;

    public float groundDistance = 0.4f;

    public LayerMask groundLayer;

    public Transform groundCheck;

    private Vector3 velocity;

    private bool isGrounded;

    private float gravity = -17f; // saatat joutua t�t� s��t�m��n fysiikan simuloimiseksi

    public float staminaDepletionRate = 3f;

    private NR_MenuScript menuScript;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
        playerStats = GetComponent<NR_PlayerStats>();

        menuScript = GetComponent<NR_MenuScript>();

        if (groundCheck == null)
        {
            Debug.LogError("Assign a GroundCheck object to the PlayerMovement script in the inspector.");
            this.enabled = false;
            return;
        }
    }

    private void Update()
    {
        if (playerStats.dead == false && menuScript.menuOpen == false)
        {
            MovePlayer();
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
            playerStats.outOfBreath = true;

            playerStats.stamina -= staminaDepletionRate * Time.deltaTime;
        }
        else
        {
            speed = walkSpeed;
            playerStats.outOfBreath = false;
        }
        
    }

    private void MovePlayer()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // pid� hahmo maassa
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 forwardDirection = cameraTransform.forward;
        Vector3 rightDirection = cameraTransform.right;

        forwardDirection.y = 0; // niin ettei pelaaja l�hde lent�m��n y akselilla.
        rightDirection.y = 0;

        forwardDirection.Normalize();
        rightDirection.Normalize();

        Vector3 desiredDirection = (forwardDirection * vertical + rightDirection * horizontal).normalized;
        Vector3 movement = desiredDirection * speed * Time.deltaTime;

        characterController.Move(movement);

        
        
    }
}