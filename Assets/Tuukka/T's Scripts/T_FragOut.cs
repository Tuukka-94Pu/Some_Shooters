using UnityEngine;
using static Unity.VisualScripting.Member;

public class T_FragOut : MonoBehaviour
{
    public GameObject pipeGrenade;
    public GameObject remoteGrenade;
    public Camera playerCamera;
    public float throwForce = 10f;
    public int fragCount = 2;
    public GameObject OOF;
    public string type;

    private bool source;
    private void Awake()

    {
        if (!playerCamera)

        {
            Debug.LogError("Assign a Camera for the script in the inspector");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        type = "Pipe";
    }

    // Update is called once per frame
    void Update()

    {
        source = GameObject.Find("bean").GetComponent<T_PlayerHealth>().playerAlive;

        if (source == true)
        {
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                if (type == "Remote" && GameObject.FindGameObjectWithTag("remotes") == null)
                {
                    type = "Pipe";
                }
                else
                {
                    type = "Remote";
                }
            }


            if (fragCount == 0)
            {
                OOF.SetActive(true);
            }
            else
            {
                OOF.SetActive(false);
            }






            if (Input.GetButtonDown("Fire2") && pipeGrenade != null && fragCount > 0)

            {
                fragCount--;

                ThrowGrenade();

            }
        }
    }
    void ThrowGrenade()

    {
        if (type == "Pipe" || remoteGrenade == null)
        {


            GameObject grenade = Instantiate(pipeGrenade, playerCamera.transform.position + playerCamera.transform.forward, Quaternion.identity);
            Rigidbody rb = grenade.GetComponent<Rigidbody>();

            if (rb != null)

            {
                rb.AddForce(playerCamera.transform.forward * throwForce, ForceMode.VelocityChange);
            }
        }
        if(type == "Remote" ||pipeGrenade == null)
        {
            GameObject remotegrenade = Instantiate(remoteGrenade, playerCamera.transform.position + playerCamera.transform.forward, Quaternion.identity);
            Rigidbody rb = remotegrenade.GetComponent<Rigidbody>();

            if (rb != null)

            {
                rb.AddForce(playerCamera.transform.forward * throwForce, ForceMode.VelocityChange);
            }
        }
    }
       public void addFrags()
    {
        fragCount++;
    }
}   
