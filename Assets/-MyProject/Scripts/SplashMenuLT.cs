using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using UnityEngine.UI;


//==============================================================
// Description: Show SplashScreen and then Menu using LeanTween 
//==============================================================

public class SplashMenuLT : MonoBehaviour
{
    [SerializeField] private GameObject _splashScr;

    [Header("Decal on Floor")]
    [SerializeField] private GameObject _decalJetHammer;
    [SerializeField] private CanvasGroup _mainMenuPanel;
    private RectTransform _splashScrRectTransform;

    protected void Awake()
    {
        _splashScr.transform.localScale = new Vector3(x: 0.8f, y: 0.8f, z: 1.0f);
        _splashScrRectTransform = _splashScr.GetComponent<RectTransform>();
        _decalJetHammer.SetActive(false);
    }

    protected void Start()
    {
        var seq = LeanTween.sequence();
        seq.append(2f); //delay everything 2 second
        seq.append(() =>
        { //fire an event
            FadeInLogo();
        });
        seq.append(3f); //delay everything 3 second
        seq.append(() =>
        { //fire an event
            FadeOutLogo();
        });

        seq.append(1f); //delay everything 1 second
       seq.append(() =>
       { //fire an event
           ShowDecalAndMenu();
        });
    }

    private void FadeInLogo()
    {
        LeanTween.scaleX(_splashScr, to: 1.2f, time: 1f);
        LeanTween.scaleY(_splashScr, to: 1.2f, time: 1f);
        LeanTween.alpha(_splashScrRectTransform, to: 1f, time: 1f);
    }

    private void FadeOutLogo()
    {
        LeanTween.scaleX(_splashScr, to: 0.8f, time: 1f);
        LeanTween.scaleY(_splashScr, to: 0.8f, time: 1f);
        LeanTween.alpha(_splashScrRectTransform, to: 0f, time: 1f);

       
    }

    private void ShowDecalAndMenu()
    {
        _decalJetHammer.SetActive(true);
        LeanTween.alphaCanvas(_mainMenuPanel, to: 1f, time: 1f);
    }
}
