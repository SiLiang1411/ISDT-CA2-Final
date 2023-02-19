using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using UnityEngine.UI;

public class FadeCamera : MonoBehaviour
{

    
    //==============================
    //Private Variables
    //==============================
    [SerializeField] private RectTransform _fadeScreenRectTransform;

    [Header("Fade Settings")]
    [SerializeField] [Range(0.1f, 3.0f)] private float _fadeInTime = 1.0f;
    [SerializeField] [Range(0.1f, 3.0f)] private float _fadeOutTime = 1.0f;


    protected void Start()
    {
        var seq = LeanTween.sequence();
        seq.append(3f); //delay everything 3 second
        seq.append(() =>
        { //fire an event
            FadeOutCam();
        });
        seq.append(2f); //delay everything 2 second
        seq.append(() =>
        { //fire an event
            FadeInCam();
        });
    }

   



    public void FadeInCam()
    {
        LeanTween.alpha(_fadeScreenRectTransform, to: 0f, _fadeInTime);
    }

    public void FadeOutCam()
    {
        LeanTween.alpha(_fadeScreenRectTransform, to: 1f, _fadeOutTime);

        //Write some logic to jump to another scene if necessary
    }


}
