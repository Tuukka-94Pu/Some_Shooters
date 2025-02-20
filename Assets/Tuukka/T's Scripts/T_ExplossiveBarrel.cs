using UnityEngine;

public class T_ExplossiveBarrel : MonoBehaviour,IDamageable
{
    public float health = 30;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if(health < 0 ) 
        {
            Destroy(gameObject);
        }
    }
}
