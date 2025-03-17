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
            Cursor.lockState = CursorLockMode.None;
           playerAlive = false;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            playerHP -= 10;
        }
    }
    public void  TakeAHit(int damage)
    {
        playerHP -= damage;
    }
}