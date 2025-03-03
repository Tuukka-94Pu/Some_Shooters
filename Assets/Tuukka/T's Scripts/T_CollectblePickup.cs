using UnityEngine;



public class T_CollectblePickup : MonoBehaviour
{
    public int score;
    private T_ShooterScript shooter;
    private T_FragOut fags;

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
            score ++;
            Destroy(other.gameObject);
            
        }
        if (other.gameObject.tag == "ammoPickup")
        {
            GameObject ammoRoot = GameObject.Find("bean");
           shooter = ammoRoot.GetComponent<T_ShooterScript>();
            shooter.addAmmo();
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag =="fragPickup")
        {
            fags = GetComponent<T_FragOut>();
            fags.addFrags();
            Destroy(other.gameObject);
        }

    }
}
