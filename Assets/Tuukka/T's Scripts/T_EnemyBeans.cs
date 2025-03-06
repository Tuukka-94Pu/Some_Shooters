using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class T_EnemyBeans : MonoBehaviour,IDamageable
{


    public float health = 100.0f;
    public GameObject droppedItem;
    public Transform Target;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = Target.position;



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
    

}

