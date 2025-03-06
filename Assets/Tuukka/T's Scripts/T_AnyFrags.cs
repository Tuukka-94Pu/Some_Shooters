using System.Collections;
using UnityEngine;

public class T_AnyFrags : MonoBehaviour
{
    public float delay = 3f;
    public float blastRadius = 5f;
    public float explosionForce = 700f;
    public float damageAmount = 50f;
    public LayerMask damageableLayer;
    public string type;
    public bool hasExploded = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject source = GameObject.Find("bean");
        type = source.GetComponent<T_FragOut>().type;

        if (type == "Pipe")
        {
            StartCoroutine(ExplodeAfterDelay());
        }
        if (Input.GetKeyUp(KeyCode.Q) )
        {
            Explode();
        }

    }
        IEnumerator ExplodeAfterDelay()
        {

        yield return new WaitForSeconds(delay);

        Explode();

        }

    void Explode()

    {

        if (hasExploded) return;

        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius, damageableLayer);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if (rb != null)

            {
                rb.AddExplosionForce(explosionForce, transform.position, blastRadius);
            }



            IDamageable damageable = nearbyObject.GetComponent<IDamageable>();

            if (damageable != null)

            {
                damageable.TakeDamage(damageAmount);
            }

        }

        

        hasExploded = true;

        Destroy(gameObject);
    }

}
