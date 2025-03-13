using UnityEngine;

public class NR_FireBall : MonoBehaviour
{
    public float flyForce = 30f;
    public float blastRadius = 5f;
    public float explosionForce = 700f;
    public float damage = 100f;
    public float stunTime = 2f;

    private bool hasExploded = false;

    public ParticleSystem fireballExplosion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Throw();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explode()
    {
        if (hasExploded) return;

        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody orb = nearbyObject.GetComponent<Rigidbody>();
            if (orb != null)
            {
                orb.AddExplosionForce(explosionForce, transform.position, blastRadius);
            }

            if (nearbyObject.tag == "Enemy")
            {
                NR_Enemy enemy = nearbyObject.GetComponent<NR_Enemy>();
                enemy.TakeDamage(damage, stunTime);
            }
        }
        Instantiate(fireballExplosion, transform.position, transform.rotation);

        hasExploded = true;
        Destroy(gameObject);
    }

    void Throw()
    {
        Camera playerCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(playerCamera.transform.forward * flyForce, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }
}
