using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoke : MonoBehaviour
{
    public ParticleSystem _fireParticle;
    public ParticleSystem _smokeParticle;

    void Start()
    {
        _smokeParticle.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (!_fireParticle.isPlaying)
        {
            _smokeParticle.Stop();
        }
    }
}
