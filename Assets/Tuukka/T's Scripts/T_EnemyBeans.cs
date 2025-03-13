
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class T_EnemyBeans : MonoBehaviour,IDamageable
{


    public float health = 100.0f;
    private float targetdistance;
    private int randomNumb;
    private int randomDam;
    private T_PlayerHealth damagePlayer;
    public GameObject droppedItem;
    public Transform Target;
    private IEnumerator something;
    private bool waiting = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        something = AttackWait(3);
    }

    // Update is called once per frame
    void Update()
    {



        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = Target.position;
       
        targetdistance = Vector3.Distance(Target.position, agent.transform.position);
    }


    void FixedUpdate() { 

        if(targetdistance <= 5) 
        {
            randomNumb = Random.Range(0, 25 );
            Debug.Log("Bang!");

            if(randomNumb ==  3 && waiting == false )
            {
                damagePlayer = GameObject.Find("bean").GetComponent<T_PlayerHealth>();
                randomDam = Random.Range(0, 5 );
                damagePlayer.TakeAHit(randomDam);
                waiting = true;
                StartCoroutine(AttackWait(3));
               // Instantiate(droppedItem,transform.position,transform.rotation);
            }
        }
    }
    public void TakeDamage(float damageAmount)

    {

        health -= damageAmount;

        Debug.Log("Enemy health is: " + health);

        if (health <= 0)

        {
            Instantiate(droppedItem,transform.position,transform.rotation);
            Destroy(gameObject);

        }

    }
    public IEnumerator AttackWait(int time)
    { 
        yield return new WaitForSeconds(time);
        waiting = false;
    }
    
    
        

}

