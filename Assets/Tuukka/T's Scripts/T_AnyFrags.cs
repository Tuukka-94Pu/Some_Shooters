using System.Collections;
using UnityEngine;

public class T_AnyFrags : MonoBehaviour
{
    public float delay = 3f;
    public float blastRadius = 5f;
    public float explosionForce = 700f;
    public float damageAmount = 50f;
    public LayerMask damageableLayer;

    private bool hasExploded = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ExplodeAfterDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
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
