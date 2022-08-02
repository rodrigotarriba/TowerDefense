using System.Collections;
using System.Collections.Generic;
using TowerDefense.Level;
using TowerDefense.Towers;
using UnityEngine;
using TowerDefense.Level;

public class FPShooting : MonoBehaviour
{
    public FPSWeapon weapon;

    [SerializeField]
    private Camera playerCamera;


    private LayerMask groundEnemyMask;
    private LayerMask flyingEnemyMask;

    private void Awake()
    {
        groundEnemyMask = LayerMask.NameToLayer("GroundEnemies");
        flyingEnemyMask = LayerMask.NameToLayer("FlyingEnemies");

    }


    private void Start()
    {
        
        
        
        if (playerCamera == null)
        {
            Debug.LogError("PlayerShoot: No camera referenced!");
            this.enabled = false;
        }
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log($"hit the fan!");
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;


        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, weapon.range, groundEnemyMask)){
            Debug.Log($"We hit {hit.collider.name}");
        }

    }
}
