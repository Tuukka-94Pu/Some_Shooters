using TMPro;
using UnityEngine;

public class NR_DamageNumberGenerator : MonoBehaviour
{

    public static NR_DamageNumberGenerator current;

    public GameObject prefab;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        current = this;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) 
        {
            CreatePopUp(Vector3.one, Random.Range(1, 500).ToString());
        }

        
    }

    public void CreatePopUp(Vector3 position, string text)
    {
        var popUp = Instantiate(prefab, position, Quaternion.identity);
        var temp = popUp.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        temp.text = text;

        Destroy(popUp, 1f);
    }
}
