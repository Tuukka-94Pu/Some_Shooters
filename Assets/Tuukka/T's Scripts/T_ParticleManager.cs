using UnityEngine;
using UnityEngine.UIElements;

public class T_ParticleManager : MonoBehaviour
{
    public GameObject smoke;
    public GameObject impactEnemy;
    public GameObject Muzzlebang;
    public GameObject muzzleFlashPoint;
    public GameObject muzzleLight;
    private Vector3 bruh;
    private Quaternion bruhRot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bruh = muzzleFlashPoint.transform.position;
        bruhRot = Quaternion.Euler(0, 0, -90);
    }

    public void SpawnSmoke(Vector3 jaa)
    {
        Instantiate(smoke, jaa, transform.rotation);
    }
    public void HitAnEnemy(Vector3 hitSpot)
    {
           Instantiate(impactEnemy, hitSpot, transform.rotation);
      
    }
    public void GunFire() 
    {

        Instantiate(Muzzlebang, bruh, bruhRot);
        Instantiate(muzzleLight, bruh, bruhRot);
    
    }



}
