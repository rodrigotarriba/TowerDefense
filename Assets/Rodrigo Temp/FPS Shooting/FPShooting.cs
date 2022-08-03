using System.Collections;
using System.Collections.Generic;
using TowerDefense.Level;
using TowerDefense.Towers;
using UnityEngine;
using TowerDefense.Level;
using Core.Health;
using ActionGameFramework.Health;

public class FPShooting : MonoBehaviour
{
    public FPSWeapon weaponStats;
    public Transform weaponPrefab;
    public float aimingSpeed; //.1 meter per second
    public GameObject bulletHit;

    public int damageDone;

    [SerializeField]
    private Camera playerCamera;

    /// <summary>
    /// Layer to be used for our ground enemies
    /// </summary>
    private int playerMask = 1 << 7;


    public GameObject sphere1;
    public GameObject floatingMinePrefab;

    private Damager FPSDamager;


    /// <summary>
    /// Bullet Speed Factor in Meters/Seconds
    /// </summary>
    public float bulletSpeed;

    private void Awake()
    {

    }


    private void Start()
    {
        FPSDamager =  GetComponent<Damager>();
        

        if (playerCamera == null)
        {
            Debug.LogError("PlayerShoot: No camera referenced!");
            this.enabled = false;
        }
    }


    private void Update()
    {
        //Aim();
        
        if (Input.GetMouseButtonDown(0))
        {
            //hit detection
            Shoot();
        }
    }



    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, weaponStats.range, ~playerMask))
        {

            if(hit.collider.gameObject.layer == (1 << 17))
            {
                Debug.Log($"generateDamage");
            }
            
            Debug.Log($"We hit {LayerMask.LayerToName(hit.collider.gameObject.layer)}");

            Instantiate(bulletHit, hit.point, Quaternion.identity);

            if (hit.collider.gameObject.GetComponent<NewEnemyDetection>())
            {
                hit.collider.gameObject.GetComponent<NewEnemyDetection>().TakeDamage(damageDone);
            }

            hit.collider.gameObject.GetComponent<DamageableBehaviour>().TakeDamage(FPSDamager.damage, hit.point, FPSDamager.alignmentProvider);


        }

    }


}
