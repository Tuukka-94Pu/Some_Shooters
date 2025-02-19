using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NR_Weapon : MonoBehaviour
{
    
    public bool isAnimating;

    public Animator animator;

    public BoxCollider hitbox;

    List<GameObject> hitList = new List<GameObject>();

    public float swingStartUp;
    public float swingLength;

    public float damage;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hitbox.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isAnimating == false)
            {
                StartCoroutine(Swing());
            }
            Debug.Log("Clicked");
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
                enemyScript.TakeDamage(damage);
            }
        }
    }

    IEnumerator Swing()
    {
        animator.SetTrigger("Animate");
        isAnimating = true;

        yield return new WaitForSeconds(swingStartUp);
        hitbox.enabled = true;

        yield return new WaitForSeconds(swingLength);
        isAnimating = false;
        hitbox.enabled = false;

        for (int i = 0; i < hitList.Count; i++)
        {
            hitList.Remove(hitList[i]);
        }

    }
}
