using System.Collections;
using UnityEngine;

public class NR_Enemy : MonoBehaviour
{
    public float health;

    public Material normalMat;
    public Material hitMat;
    
    public Animator animator;
    public ParticleSystem deathParticle;

    public bool takingDamage = false;

    public NR_EnemyAI ai;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage, float stunTime)
    {
        health -= damage;
        Debug.Log("health: " + health);
        animator.Play("Color", -1, 0f);

        StartCoroutine(DamageStun());

        ai = GetComponent<NR_EnemyAI>();

        if (ai != null)
        {
            ai.Activate();
        }

        IEnumerator DamageStun()
        {
            takingDamage = true;
            yield return new WaitForSeconds(stunTime);
            takingDamage = false;
        }

        if (health <= 0)
        {
            Die();
        }
    }

   public void Die()
   {
       Instantiate(deathParticle, transform.position, transform.rotation);
       Destroy(gameObject);
   }
}
