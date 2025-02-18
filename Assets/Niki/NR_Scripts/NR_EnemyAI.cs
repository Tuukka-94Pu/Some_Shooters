using UnityEngine;

public class NR_EnemyAI : MonoBehaviour
{

    public bool active;

    private GameObject player;
    private Transform playerPos;
    public float rotationSpeed = 1f;
    public float movementSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            Vector3 relativePos = playerPos.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
            
            float angleToPlayer = Vector3.Angle(transform.forward, relativePos);
            Vector3 turnAxis = Vector3.Cross(transform.forward, relativePos);

            if (angleToPlayer < 90)
            { 
                transform.position = Vector3.MoveTowards(transform.position, playerPos.transform.position, Time.deltaTime * movementSpeed);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            Activate();
            playerPos = other.transform;
            
        }
    }

    private void Activate()
    {
        active = true;
        
    }


}
