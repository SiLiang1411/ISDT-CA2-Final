using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Attach this script to enemy
public class EnemyDamage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(15);
        }
    }
}
