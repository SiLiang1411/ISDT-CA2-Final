using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")] [SerializeField] private float shotPower = 500f;
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;

    public AudioSource source;
    public AudioClip fireSound;
    public AudioClip reload;
    public AudioClip noAmmo;

    public Transform gunTransform;
    public float lineLength = 100f;
    private LineRenderer lineRenderer;

    public Magazine magazine;
    public XRBaseInteractor socketInteractor;
    private bool hasSlide = true;

    public float range = 100f;
    public Transform firePoint;

    [SerializeField] private GameObject _bulletHolePrefab; 
    public void AddMagazine(XRBaseInteractable interactable) 
    {
        magazine = interactable.GetComponent<Magazine>();
        source.PlayOneShot(reload);
        hasSlide = false;
    }

    public void RemoveMagazine(XRBaseInteractable interactable)
    {
        magazine = null;
        source.PlayOneShot(reload);

    }

    public void Slide()
    {
        hasSlide = true;
        source.PlayOneShot(reload);
    }
    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();

        socketInteractor.onSelectEntered.AddListener(AddMagazine);
        socketInteractor.onSelectExited.AddListener(RemoveMagazine);

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.positionCount = 2;
    }

   public void PullTrigger()
    {
        if(magazine && magazine.numberOFBullet > 0 && hasSlide)
        {
            gunAnimator.SetTrigger("Fire");
        }
        else
        {
            source.PlayOneShot(noAmmo);
        }
        
    }


    //This function creates the bullet behavior
    void Shoot()
    {
        magazine.numberOFBullet--;
        Debug.Log("Bullets Left: " + magazine.numberOFBullet + "/15");
        source.PlayOneShot(fireSound);
        if (muzzleFlashPrefab)
        {
            //Create the muzzle flash
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            //Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }

        //=======================================
        /*
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right, range);
        if (hitInfo)
        {
            Debug.DrawRay(firePoint.position, firePoint.right * hitInfo.distance, Color.red);
           
        }
        else
        {
            Debug.DrawRay(firePoint.position, firePoint.right * range, Color.green);
        }
        */
        //=======================================
        Ray ray = new Ray(gunTransform.position, gunTransform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            string objectName = hitObject.name;
            Debug.Log("Hit object: " + objectName);
        }

        
        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {// returns true if ray touches something
            GameObject obj = Instantiate(_bulletHolePrefab, hit.point, Quaternion.LookRotation(hit.normal));
            //instantiating the bullet hole
            obj.transform.position += obj.transform.forward / 1000;
            //changing the bullet hole's position a bit so it will fit better
        }

        //=======================================

        //cancels if there's no bullet prefeb
        if (!bulletPrefab)
        { return; }

        // Create a bullet and add force on it in direction of the barrel
        Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

    }

    //This function creates a casing at the ejection slot
    void CasingRelease()
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab)
        { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }

    void Update()
    {
        Vector3 startPos = firePoint.position;
        Vector3 endPos = startPos + firePoint.forward * lineLength;
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}
