using UnityEngine;



public class T_CollectblePickup : MonoBehaviour
{
    public int score;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            score++;
            Destroy(other.gameObject);
            
        }

    }
}
