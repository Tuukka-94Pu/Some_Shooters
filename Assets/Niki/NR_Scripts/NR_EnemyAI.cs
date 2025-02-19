using System.Collections;
using UnityEngine;

public class NR_EnemyAI : MonoBehaviour
{

    public bool active;

    private GameObject player;
    private Transform playerPos;
    public float rotationSpeed = 1f;
    public float movementSpeed = 1f;

    public bool attacking = false;
    public bool attackHit = false;

    public NR_Enemy enemyScript;
    public NR_PlayerStats playerStats;

    public GameObject activeArea;
    public BoxCollider hitbox;

    public bool attackCooldown;

    public float attackRange = 2f;

    public float damage = 20f;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hitbox.enabled = false;
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true && attacking == false)
        {
            float distanceFromPlayer = Vector3.Distance(playerPos.position, transform.position);

            Vector3 relativePos = playerPos.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

            

            float angleToPlayer = Vector3.Angle(transform.forward, relativePos);
            Vector3 turnAxis = Vector3.Cross(transform.forward, relativePos);

            if (transform.rotation.y != 0)
            {
                rotation.y = 0;
            }

            if (angleToPlayer < 90 && attacking == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, playerPos.transform.position, Time.deltaTime * movementSpeed);

                
            }

            if (distanceFromPlayer < attackRange && angleToPlayer < 50 && attackCooldown == false)
            {
                StartCoroutine(Attack(0.13f, 0.2f, 0.75f, 0.5f));

                Debug.Log("Attack");
            }


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && active == false)
        {
            player = other.gameObject;
            playerStats = other.GetComponent<NR_PlayerStats>();

            StartCoroutine(DespawnArea(0.1f));
            
            playerPos = other.transform;
            
        }
    }



    private void Activate()
    {
        active = true;
        activeArea.SetActive(false);
    }

    IEnumerator Attack(float startUp, float duration, float recovery, float cooldown)
    {
        

        attacking = true;
        enemyScript.animator.SetBool("attacking", true);
        yield return new WaitForSeconds(startUp);

        hitbox.enabled = true;
        yield return new WaitForSeconds(duration);
        enemyScript.animator.SetBool("attacking", false);
        hitbox.enabled = false;
        yield return new WaitForSeconds(recovery);
        attacking = false;
        

        attackCooldown = true;
        yield return new WaitForSeconds(cooldown);
        attackCooldown = false;
        attackHit = false;
    }

    IEnumerator DespawnArea(float duration)
    {
        yield return new WaitForSeconds(duration);
        Activate();
    }
}
