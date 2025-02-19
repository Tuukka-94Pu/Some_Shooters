using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NR_PlayerStats : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health = 100f;
    public Image healthBar;
    public Image damageFlash;
    public Animator animator;

    public bool dead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(20);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / 100;

        animator.Play("DamageSquare", -1, 0f);

        if (health <= 0)
        {
            health = 0;
            dead = true;
        }
    }

    public void Heal(float ammount)
    {
        health += ammount;
        healthBar.fillAmount = health / 100;
        animator.Play("HealSquare", -1, 0f);

        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Weapon" || other.gameObject.name == "Hitbox")
        {
            NR_EnemyAI enemyAI = other.GetComponentInParent<NR_EnemyAI>();

            if (enemyAI.attackHit == false)
            {
                TakeDamage(enemyAI.damage);
                enemyAI.attackHit = true;
            }
        }
    }
}
