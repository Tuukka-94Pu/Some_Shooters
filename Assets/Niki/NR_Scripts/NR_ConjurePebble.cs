using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NR_ConjurePebble : MonoBehaviour
{

    public float flyForce = 50f;
    public float damage = 10f;
    public float stunTime = 0.2f;

    List<GameObject> hitList = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Throw();
        StartCoroutine(DestroyAfterDelay(5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Throw()
    {
        Camera playerCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(playerCamera.transform.forward * flyForce, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!hitList.Contains(collision.gameObject))
            {
                hitList.Add(collision.gameObject);
                NR_Enemy enemyScript = collision.gameObject.GetComponent<NR_Enemy>();

                enemyScript.TakeDamage(damage, stunTime);
            }
        }
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
