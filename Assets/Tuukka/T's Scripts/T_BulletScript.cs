using System.Collections;
using UnityEngine;

public class T_BulletScript : MonoBehaviour
{
    private IEnumerator test;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        test = TillDeletion(2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward);
        StartCoroutine(TillDeletion(2));
    }

    private IEnumerator TillDeletion(int time) 
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != null)
        {
            Destroy(gameObject);
        }
    }
}
