using System.Collections;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class T_AnyFrags : MonoBehaviour
{
    public float delay = 3f;
    public float blastRadius = 5f;
    public float explosionForce = 700f;
    public float damageAmount = 50f;
    public LayerMask damageableLayer;
    public string type;
    private T_ParticleManager call;
    public bool hasExploded = false;
    public GameObject smoke;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        GameObject source = GameObject.Find("bean");
        GameObject partics = GameObject.Find("Unity's Particle system, a great system");
        type = source.GetComponent<T_FragOut>().type;
        call = partics.GetComponent<T_ParticleManager>();

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

        
        call.SpawnSmoke(transform.position);


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
