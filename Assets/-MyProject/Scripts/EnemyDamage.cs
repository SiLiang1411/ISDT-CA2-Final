using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Attach this script to enemy
public class EnemyDamage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public  GameObject enemy;
    public  GameObject player;
    float timePassed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position,enemy.transform.position);
        Debug.Log(distance);
       
        if (distance<1f){
             timePassed += Time.deltaTime;
             Debug.Log(timePassed);
            if(timePassed > 2.26f){
            playerHealth.TakeDamage(20);//do something
            timePassed=0f;
        } 
         }
    }

   
}
