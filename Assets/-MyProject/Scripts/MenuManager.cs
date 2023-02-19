using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    AudioSource _BGM;
    public GameObject _decal;

    void Start()
    {
        _BGM = GetComponent<AudioSource>();
        AudioListener.pause = true;
        
    }
    // Update is called once per frame
    void Update()
    {
        if(_decal.activeInHierarchy == true)
        {
            AudioListener.pause = false;
        }
    }
}
