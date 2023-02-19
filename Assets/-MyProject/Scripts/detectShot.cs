using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectShot : MonoBehaviour
{

    public ParticleSystem water;
    public int numBulletHoles;

    

    void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.tag == "bulletHole")
          {
            Debug.Log("Water Tower shot by gun");
              collision.transform.parent = transform;
          }

         if(collision.gameObject.tag == "bulletHole" && gameObject.tag == "enemy")
        {
            gameObject.SetActive(false);
        }
     }

    void Update()
    {
        numBulletHoles = transform.childCount;

        if(numBulletHoles == 3)
        {
            Debug.Log("Water Tower has 3 bullet holes");
            water.Play();
        }
    }
    
}
