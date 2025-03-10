using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class NR_PlayerStats : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health = 100f;
    public float healingConsumables = 0;
    public TextMeshProUGUI healingConsumableAmmount;

    public float maxStamina = 10f;
    public float stamina = 10f;
    public bool outOfBreath = false;

    public float maxMana = 100f;
    public float mana = 100f;
    public float spellCooldownFloat;
    public float manaConsumables;
    public TextMeshProUGUI manaConsumableAmmount;


    public Image healthBar;
    public Image damageFlash;
    public Animator damageAnimator;
    public Animator manaBarAnimator;

    public Image staminaBar;

    public Image manaBar;

    public Image spellCooldownBar;

    public bool dead;

    public bool spellIsInHand;
    public NR_SpellInHand spellInHand;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spellInHand = gameObject.GetComponentInChildren<NR_SpellInHand>();
        healingConsumableAmmount.text = "" + healingConsumables;
        manaConsumableAmmount.text = "" + manaConsumables;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && healingConsumables > 0)
        {
            Heal(20);
            healingConsumables--;
            healingConsumableAmmount.text = "" + healingConsumables;
        }

        if (Input.GetKeyDown(KeyCode.G) && manaConsumables > 0)
        {
            ManaFill(20);
            manaConsumables--;
            manaConsumableAmmount.text = "" + manaConsumables;
        }

        staminaBar.fillAmount = stamina / maxStamina;

        if (stamina < 0)
        {
            stamina = 0;
        }

        SpellCooldown();
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / maxHealth;

        damageAnimator.Play("DamageSquare", -1, 0f);

        if (health <= 0)
        {
            health = 0;
            dead = true;
        }
    }

    public void Heal(float ammount)
    {
        health += ammount;
        healthBar.fillAmount = health / maxHealth;
        damageAnimator.Play("HealSquare", -1, 0f);

        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public void ManaFill(float ammount)
    {
        mana += ammount;
        manaBar.fillAmount = mana / maxMana;
        manaBarAnimator.Play("ManaFlash", -1, 0f);

        if (mana >= maxMana)
        {
            mana = maxMana;
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

    void SpellCooldown()
    {
        if (spellInHand != null) { spellIsInHand = true; }

        if (!spellIsInHand)
        {
            spellCooldownFloat = 0;
        }
        else if (!spellInHand.onCooldown)
        {
            spellCooldownFloat = spellInHand.cooldown;
        }

        spellCooldownBar.fillAmount = spellCooldownFloat / spellInHand.cooldown;

        if (spellIsInHand && spellInHand.onCooldown == true)
        {
            spellCooldownFloat += Time.deltaTime;
        }
    }
}
