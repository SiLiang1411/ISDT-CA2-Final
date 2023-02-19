using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseFireOnCollision : MonoBehaviour
{
    public ParticleSystem fire;
    public string collisionTag;
    public float increaseAmount;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == collisionTag)
        {
            Debug.Log("Fire Increase");
            var main = fire.main;
            main.startSize = main.startSize.constant + increaseAmount;
            this.gameObject.SetActive(false);
        }
    }
}
