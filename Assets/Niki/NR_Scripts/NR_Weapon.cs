using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NR_Weapon : MonoBehaviour
{
    
    public bool isAnimating;

    public Animator animator;

    

    List<GameObject> hitList = new List<GameObject>();

    
    public float swingLength;

    public float damage;
    public float staminaChargeRate;

    public float stunTime;

    private NR_PlayerStats playerStats;
    private NR_MenuScript menuScript;

    public Transform weaponPos;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuScript = GameObject.FindWithTag("Player").GetComponent<NR_MenuScript>();

        playerStats = GameObject.FindWithTag("Player").GetComponent<NR_PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerStats.dead == false && menuScript.menuOpen == false)
        {
            if (isAnimating == false)
            {
                StartCoroutine(Swing());
            }
            Debug.Log("Clicked");
        }


        if (playerStats.dead == false && playerStats.outOfBreath == false && isAnimating == false)
        {
            if(playerStats.stamina < playerStats.maxStamina)
            {
                playerStats.stamina += staminaChargeRate * Time.deltaTime;
            }
        }

    }

    
    

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!hitList.Contains(collision.gameObject))
            {
                hitList.Add(collision.gameObject);
                NR_Enemy enemyScript = collision.gameObject.GetComponent<NR_Enemy>();

                enemyScript.TakeDamage(Mathf.Round(damage * playerStats.stamina), stunTime);
            }
        }
    }

    IEnumerator Swing()
    {
        animator.SetTrigger("Animate");
        isAnimating = true;

        
        

        yield return new WaitForSeconds(swingLength);
        isAnimating = false;
        

        for (int i = 0; i < hitList.Count; i++)
        {
            hitList.Remove(hitList[i]);
        }
        playerStats.stamina = 0f;
    }

    
}
