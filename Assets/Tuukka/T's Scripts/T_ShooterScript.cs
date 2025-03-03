using UnityEngine;

public class T_ShooterScript : MonoBehaviour
{

    public float range = 100.0f;

    public float damage = 25.0f;

    public Camera fpsCamera;

    public LayerMask shootingLayer;

    public int ammoCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ammoCount = 10;
    }

    // Update is called once per frame
    void Update()

    {

        if (Input.GetButtonDown("Fire1")&& ammoCount > 0)

        {

            Shoot();
            ammoCount --;
        }
        if(Input.GetButtonDown("Fire1") && ammoCount == 0)
        {
            Debug.Log("Out of ammo!");
        }

    }

    void Shoot()

    {

        RaycastHit hit;

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range, shootingLayer))

        {

            // Debuggausta, piirrell‰‰n drawray, kun osutaan kohteeseen

            Debug.DrawRay(fpsCamera.transform.position, fpsCamera.transform.forward * range, Color.red, 2.0f);

            // checkaa jos objekti on sellainen mihin voi osua

            IDamageable damageable = hit.transform.GetComponent<IDamageable>();

            if (damageable != null)

            {

                damageable.TakeDamage(damage);

            }

        }

    }

}

// t‰ss‰ se interface nyt tehd‰‰n

                public interface IDamageable

                        {
            
                 void TakeDamage(float damageAmount);

                         }

