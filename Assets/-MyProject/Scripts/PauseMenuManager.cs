using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    public Sprite playIcon;
    public Sprite pauseIcon;

    private bool isPlaying = true;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        //button.onClick.AddListener(handlePausePlay);
        button.image.sprite = playIcon;
    }

    public void handlePausePlay()
    {
        isPlaying = !isPlaying;
        if (isPlaying)
        {
           
            button.image.sprite = playIcon;
            Debug.Log("Resuming Game");
            Time.timeScale = 1f;
            // Resume gameplay or animation
        }
        else
        {
       
            Time.timeScale = 0f;
            Debug.Log("Game Pause");
            button.image.sprite = pauseIcon;
            // Pause gameplay or animation
        }
    }
}
