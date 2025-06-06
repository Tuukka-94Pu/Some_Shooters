using System.Collections;
using UnityEngine;

public class T_ShooterScript : MonoBehaviour
{

    public float range = 100.0f;

    public float damage = 25.0f;

    public Camera fpsCamera;

    public LayerMask shootingLayer;

    public int ammoCount;

    public GameObject Pistol;

    public GameObject Rifle;

    private IEnumerator coroutine;

    private IEnumerator weaponSwitch;

    public GameObject OOA;

    private string weapon = "Pistol";

    private T_ParticleManager bloodSpat;

    private T_ParticleManager Gunflash;

    private bool source;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ammoCount = 10;
        coroutine = waitForRecoil(2, 0);

    }

    // Update is called once per frame
    void Update()

    {
        Gunflash = GameObject.Find("Unity's Particle system, a great system").GetComponent<T_ParticleManager>();  
        source = GetComponent<T_PlayerHealth>().playerAlive;
        
        if (source == true)

        {

            if (ammoCount == 0)
            {
                OOA.SetActive(true);
            }
            else
            {
                OOA.SetActive(false);
            }
            // Switch weapon if the weapon to be switched to is not the current one
            if (Input.GetKeyDown(KeyCode.Alpha1) && weapon != "Pistol")
            {
                Rifle.SetActive(false);
                Pistol.SetActive(true);
                weapon = "Pistol";
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && weapon != "Rifle")
            {
                Pistol.SetActive(false);
                Rifle.SetActive(true);
                weapon = "Rifle";
            }

            //Fire the gun, weapon type determines damage and recoil
            if (Input.GetButtonDown("Fire1") && ammoCount > 0 && weapon == "Pistol")

            {
                damage = 10.0f;
                Shoot();
                Recoil(4, 0.3f);
                ammoCount--;
            }
            if (Input.GetButtonDown("Fire1") && ammoCount > 1 && weapon == "Rifle")
            {
                damage = 25.0f;
                Shoot();
                Recoil(5, 0.5f);
                ammoCount--;
                ammoCount--;
            }

        }
    }

    public void addAmmo()
    {
        ammoCount += 5;
        
    }
    //Apply recoil to weapon and start waitForRecoil coroutine
    public void Recoil(int recoil, float waitTime)
    {
        if(weapon == "Pistol")
        {
            Pistol.transform.Rotate(-recoil, 0, 0);

            StartCoroutine(waitForRecoil(waitTime,recoil));

        }
        if(weapon == "Rifle")
        {
            Rifle.transform.Rotate(-recoil, 0, 0);

            StartCoroutine(waitForRecoil(waitTime,recoil));
        }
       
        
    }

    //When the coroutine ends , lower weapon down by the recoil amount 
    IEnumerator waitForRecoil(float wait,int lowering)
    {
            if(weapon == "Pistol")
        {
            yield return new WaitForSeconds(wait);
            Pistol.gameObject.transform.Rotate(lowering, 0, 0);
        }
        if((weapon == "Rifle"))
        {
            yield return new WaitForSeconds(wait);
            Rifle.gameObject.transform.Rotate(lowering, 0, 0);
        }

    }
    
    void Shoot()

    {
        Gunflash.GunFire();

        RaycastHit hit;

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range, shootingLayer))

        {
            bloodSpat = GameObject.Find("Unity's Particle system, a great system").GetComponent<T_ParticleManager>();

            bloodSpat.HitAnEnemy(hit.point);

            // Debuggausta, piirrell��n drawray, kun osutaan kohteeseen

          //  Debug.DrawRay(fpsCamera.transform.position, fpsCamera.transform.forward * range, Color.red, 2.0f);

            // checkaa jos objekti on sellainen mihin voi osua

            IDamageable damageable = hit.transform.GetComponent<IDamageable>();

            if (damageable != null)

            {

                damageable.TakeDamage(damage);

            }

        }

    }

}

// t�ss� se interface nyt tehd��n

                public interface IDamageable

                        {
            
                 void TakeDamage(float damageAmount);

                         }

