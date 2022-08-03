using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Game;

public class TowerPortal : MonoBehaviour
{
    [HideInInspector]
    public CameraManager cameraManager;



    public void Start()
    {
        cameraManager = FindObjectOfType<CameraManager>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            cameraManager.currentPlayerMode = PlayerMode.ShootingTower;
            TurretController.turretEnable = true;
            other.gameObject.transform.position = other.gameObject.transform.position + new Vector3(-1.5f, 0f, -1.5f);
        }
    }

}
