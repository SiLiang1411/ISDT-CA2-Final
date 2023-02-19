using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class SliderData
{
    public float sliderValue;
}

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Image SoundOnIcon;
    [SerializeField] Image SoundOffIcon;


    private string filePath;
    // Start is called before the first frame update
    void Start()
    {
       

        SoundOffIcon.enabled = false;
        SoundOnIcon.enabled = true;
        /*
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
        */
        Load();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    
    private void Load()
    {
        Debug.Log(Application.persistentDataPath);
        //volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
     
        filePath = Application.dataPath + "/Output/sliderdata.json";
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            SliderData sliderData = JsonUtility.FromJson<SliderData>(jsonData);
            volumeSlider.value = sliderData.sliderValue;
        }
        else
        {
            volumeSlider.value = 1f;
        }
    }

    private void Save()
    {
        // PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
        SliderData sliderData = new SliderData();
        sliderData.sliderValue = volumeSlider.value;
        string jsonData = JsonUtility.ToJson(sliderData);
        File.WriteAllText(filePath, jsonData);
    }

    void Update()
    {
        if(volumeSlider.value == 0)
        {
            SoundOffIcon.enabled = true;
            SoundOnIcon.enabled = false;
        }
        else
        {
            SoundOffIcon.enabled = false;
            SoundOnIcon.enabled =true;
        }
    }
}
