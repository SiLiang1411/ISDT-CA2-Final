using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 100f; //100sec = 1min40s

    [SerializeField] TextMeshProUGUI _countdownText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        _countdownText.text = currentTime.ToString("0");

        if(currentTime <= 0)
        {
            currentTime = 0;
        }

        if(currentTime < 11f)
        {
            _countdownText.color = new Color(1.0f, 0.8f, 0f, 1.0f); //yellow color
        }
        if (currentTime < 5f)
        {
            _countdownText.color = new Color(255.0f, 0f, 0f, 1.0f); //red color
        }
    }
}
