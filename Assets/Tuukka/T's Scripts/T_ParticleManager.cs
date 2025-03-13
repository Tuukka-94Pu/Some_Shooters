using UnityEngine;

public class T_ParticleManager : MonoBehaviour
{
    public GameObject smoke;
    public GameObject impactEnemy;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnSmoke(Vector3 jaa)
    {
        Instantiate(smoke, jaa, transform.rotation);
    }
    public void HitAnEnemy(Vector3 hitSpot)
    {
           Instantiate(impactEnemy, hitSpot, transform.rotation);
      
    }



}
