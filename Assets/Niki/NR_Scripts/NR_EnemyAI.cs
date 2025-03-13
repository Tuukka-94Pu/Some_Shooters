using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.AI;

public class NR_EnemyAI : MonoBehaviour
{

    public bool active;

    private NavMeshAgent agent;

    private GameObject player;
    private Transform playerPos;
    public float rotationSpeed = 1f;
    public float movementSpeed = 1f;

    public bool attacking = false;
    public bool attackHit = false;
    
    public float attackDuration = 0.33f;
    public float attackRecovery = 0.75f;
    public float attackCooldownTime = 0.5f;

    public NR_Enemy enemyScript;
    public NR_PlayerStats playerStats;

    
    public BoxCollider hitbox;

    public bool attackCooldown;

    public float attackRange = 2f;

    public float damage = 20f;

    public float distanceFromPlayer;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyScript = GetComponent<NR_Enemy>();
        player = GameObject.FindWithTag("Player");
        playerStats = player.GetComponent<NR_PlayerStats>();
        agent = GetComponent<NavMeshAgent>();

        hitbox.enabled = false;
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform;
        distanceFromPlayer = Vector3.Distance(playerPos.position, transform.position);
        if (distanceFromPlayer < 10)
        {
            Activate();
        }

        if (active == true && attacking == false && enemyScript.takingDamage == false)
        {


            Vector3 relativePos = playerPos.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);



            float angleToPlayer = Vector3.Angle(transform.forward, relativePos);
            Vector3 turnAxis = Vector3.Cross(transform.forward, relativePos);



            if (angleToPlayer < 90 && attacking == false && distanceFromPlayer > attackRange)
            {
                agent.destination = playerPos.position;
                agent.isStopped = false;
            }
            else
            {
                agent.isStopped = true;
            }

            if (distanceFromPlayer < attackRange && angleToPlayer < 50 && attackCooldown == false)
            {
                StartCoroutine(Attack(attackDuration, attackRecovery, attackCooldownTime));

                Debug.Log("Attack");
            }


        }

    }

    void ActivatedMovement()
    {
        if (active == true && attacking == false && enemyScript.takingDamage == false)
        {


            Vector3 relativePos = playerPos.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);



            float angleToPlayer = Vector3.Angle(transform.forward, relativePos);
            Vector3 turnAxis = Vector3.Cross(transform.forward, relativePos);



            if (angleToPlayer < 90 && attacking == false && distanceFromPlayer > attackRange)
            {
                agent.destination = playerPos.position;

            }

            if (distanceFromPlayer < attackRange && angleToPlayer < 50 && attackCooldown == false)
            {
                StartCoroutine(Attack(attackDuration, attackRecovery, attackCooldownTime));

                Debug.Log("Attack");
            }


        }
    }




    public void Activate()
    {
        active = true;
        
    }

    IEnumerator Attack(float duration, float recovery, float cooldown)
    {
        

        attacking = true;
        enemyScript.animator.SetBool("attacking", true);

        yield return new WaitForSeconds(duration);
        enemyScript.animator.SetBool("attacking", false);
        
        yield return new WaitForSeconds(recovery);
        attacking = false;
        attackCooldown = true;

        yield return new WaitForSeconds(cooldown);
        attackCooldown = false;
        attackHit = false;
    }


    
}
