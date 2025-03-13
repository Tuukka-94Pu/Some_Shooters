using System.Collections;
using UnityEngine;

public class T_ParticleRemover : MonoBehaviour
{
    private IEnumerator killTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        killTime = killParticle();
        StartCoroutine(killTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator killParticle()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
