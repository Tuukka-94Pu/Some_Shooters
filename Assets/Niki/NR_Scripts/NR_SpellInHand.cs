using System.Collections;
using UnityEngine;

public class NR_SpellInHand : MonoBehaviour
{
    public GameObject activeSpellPrefab;

    public Camera playerCamera;

    public MeshRenderer meshRenderer;

    public float cooldown = 5f;
    public bool onCooldown = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && onCooldown == false)
        {
            StartCoroutine(SpellActivate());
        }
    }

    IEnumerator SpellActivate()
    {
        Instantiate(activeSpellPrefab, playerCamera.transform.position + playerCamera.transform.forward, Quaternion.identity);
        onCooldown = true;
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
        meshRenderer.enabled = true;
    }
}
