using System.Collections;
using UnityEngine;

public class NR_SpellInHand : MonoBehaviour
{
    public GameObject activeSpellPrefab;

    public NR_MenuScript menuScript;

    public NR_PlayerStats playerStats;
    public Camera playerCamera;

    public MeshRenderer meshRenderer;

    public float cooldown = 5f;
    public bool onCooldown = false;

    public float manaCost;

    public Transform spellTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        playerStats = GameObject.FindWithTag("Player").GetComponent<NR_PlayerStats>();
        menuScript = GameObject.FindWithTag("Player").GetComponent<NR_MenuScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && onCooldown == false && manaCost <= playerStats.mana && menuScript.menuOpen == false)
        {
            CastSpell();
        }
    }

    public IEnumerator SpellCooldown()
    {
        

        onCooldown = true;
        

        meshRenderer.enabled = false;
        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
        meshRenderer.enabled = true;
    }

    public void CastSpell()
    {
        playerStats.spellCooldownFloat = 0f;
        Instantiate(activeSpellPrefab, playerCamera.transform.position + playerCamera.transform.forward, Quaternion.identity);
        playerStats.mana = playerStats.mana - manaCost;
        playerStats.manaBar.fillAmount = playerStats.mana / playerStats.maxMana;
        Debug.Log("mana: " + playerStats.mana);

        StartCoroutine(SpellCooldown());
    }
}
