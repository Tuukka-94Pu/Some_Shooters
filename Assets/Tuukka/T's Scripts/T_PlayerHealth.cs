using UnityEngine;
using UnityEngine.InputSystem;

public class T_PlayerHealth : MonoBehaviour
{

    public int playerHP = 100;
    public bool playerAlive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHP = 100;
        
    }

    // Update is called once per frame
    void Update()
    {
      
        

        if (playerHP <= 0)
        {
            //When player health is zero or lower unlock cursor and set player to be dead
            Cursor.lockState = CursorLockMode.None;
           playerAlive = false;
            //this variable is read in all scripts responsible for input
        }
        //Debug tool
        if (Input.GetKeyDown(KeyCode.K))
        {
            playerHP -= 10;
        }
    }
    //Only enemies shouldd call this
    public void  TakeAHit(int damage)
    {
        playerHP -= damage;
    }
}