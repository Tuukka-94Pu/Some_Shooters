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
    public float spellCooldownFloat = 0f;
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

    public GameObject currentWeapon;
    public GameObject equippedWeapon;
    public NR_Weapon weaponScript;

    public GameObject currentSpell;
    public GameObject equippedSpell;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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

        if (Input.GetKeyDown(KeyCode.C) && manaConsumables > 0)
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

        if (spellInHand != null)
        {
            

            spellCooldownBar.fillAmount = spellCooldownFloat / spellInHand.cooldown;

            if (spellInHand.onCooldown == true)
            {
                spellCooldownFloat += Time.deltaTime;

                Debug.Log("Cooldown: " + spellCooldownFloat);
            }
        }
        else
        {
            spellCooldownFloat = 0f;
            spellCooldownBar.fillAmount = spellCooldownFloat / 100f;
        }
    }

    public void HealSpell()
    {
        if (mana > 30)
        {
            Heal(40);
            mana -= 30;
            manaBar.fillAmount = mana / maxMana;
        }
    }

    public void SelectWeapon(GameObject weapon)
    {

        if (weapon != currentWeapon)
        {
            Destroy(equippedWeapon);
            weaponScript = weapon.GetComponent<NR_Weapon>();
            equippedWeapon = Instantiate(weapon, GameObject.Find("WeaponSpot").transform, weaponScript.weaponPos);
            currentWeapon = equippedWeapon;
            

            stamina = 0;
        }
    }

    public void SelectSpell(GameObject spell)
    {
        if (currentSpell == null || spellInHand.onCooldown == false) 
        {

            if (spell != currentSpell)
            {
                spellIsInHand = true;

                Destroy(equippedSpell);
                spellInHand = spell.GetComponent<NR_SpellInHand>();
                equippedSpell = Instantiate(spell, GameObject.Find("SpellSpot").transform, spellInHand.spellTransform);
                currentSpell = equippedSpell;
                spellInHand.onCooldown = true;

                StartCoroutine(spellInHand.SpellCooldown());
                spellCooldownFloat = 0;
                
            }
        }
    }
}
