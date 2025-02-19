using System.Collections;
using UnityEngine;

public class NR_Enemy : MonoBehaviour
{
    public float health;

    public Material normalMat;
    public Material hitMat;
    
    public Animator animator;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("health: " + health);
        animator.Play("Color", -1, 0f);
        
        if (health <= 0)
        {
            Die();
        }
    }

   public void Die()
    {
        Destroy(gameObject);
    }
}
