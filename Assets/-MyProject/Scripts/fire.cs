using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public ParticleSystem fireParticles;
    public ParticleSystem waterParticles;
    private ParticleSystem.EmissionModule fireEmission;
    private ParticleSystem.MainModule waterMain;

    private int numCollisions = 0;
    public float delay = 3f;
    public float sizeMultiplier = 1.5f;


    void Start()
    {
        fireEmission = fireParticles.emission;
        waterMain = waterParticles.main;
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("water"))
        {
            Debug.Log("Water Detected");
            StartCoroutine(reduceSizeOverTime());
        }
    }

  

    IEnumerator reduceSizeOverTime()
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Fire Extinguish Start");
        numCollisions++;
        float reduction = Mathf.Clamp01(numCollisions / (float)waterMain.maxParticles);
        fireEmission.rateOverTimeMultiplier = 1f - reduction;
    }

  

    void Update()
    {
        if(fireParticles.particleCount == 5)
        {
            fireParticles.Stop();
        }
    }
}
