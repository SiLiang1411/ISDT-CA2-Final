using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using UnityEngine.UI;
public class ShowLevelPanel : MonoBehaviour
{
    [SerializeField] private GameObject _PanelToDisable;
    [SerializeField] private GameObject _PanelToEnable;

    private RectTransform _menuPanelRectTransform;


    // Start is called before the first frame update
    private void Start()
    {
        if(_PanelToEnable.gameObject.name == "LevelSelect Panel")
        _PanelToEnable.SetActive(false);
    }
    public void LevelPanelAppear()
    {

        _PanelToDisable.SetActive(false);
        _PanelToEnable.SetActive(true);
    }
}
