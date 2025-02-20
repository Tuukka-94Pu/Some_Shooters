using UnityEngine;

public class T_MoveThePlayer : MonoBehaviour
{
    public float speed = 5.0f;
    private CharacterController characterController;
    private Transform cameraTransform;
    private Vector3 velocity;
    private bool isGrounded;
    private float gravity = -9.81f;
    public float jumpHeight = 2.0f;
    public float groundDistance = 0.4f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
        if (groundCheck == null)

        {

            Debug.LogError("Assign a GroundCheck object to the PlayerMovement script in the inspector.");

            this.enabled = false;

            return;

        }
    }


    // Update is called once per frame
    void Update()
    {
        {

            MovePlayer();

        }


    }
        private void MovePlayer()

        {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (isGrounded && velocity.y < 0)

        {

            velocity.y = -2f; // pid� hahmo maassa

        }
        float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");



            Vector3 forwardDirection = cameraTransform.forward;
            Vector3 rightDirection = cameraTransform.right;



            forwardDirection.y = 0; // niin ettei pelaaja l�hde lent�m��n y akselilla.
            rightDirection.y = 0;



            forwardDirection.Normalize();
            rightDirection.Normalize();



            Vector3 desiredDirection = (forwardDirection * vertical + rightDirection * horizontal).normalized;
            Vector3 movement = desiredDirection * speed * Time.deltaTime;



            characterController.Move(movement);

        // hyppy logiikka

        if (Input.GetButtonDown("Jump") && isGrounded)



        {

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }



        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

    }
    }


