using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
public class bulletCountUI : MonoBehaviour
{
    public Magazine magazine;
    public TextMeshProUGUI _bulletCount;
    private XRBaseInteractable interactable;
    // Start is called before the first frame update
    void Start()
    {
        magazine = interactable.GetComponent<Magazine>();
    }

    // Update is called once per frame
    void Update()
    {
        _bulletCount.text = magazine.numberOFBullet.ToString();
    }
}
