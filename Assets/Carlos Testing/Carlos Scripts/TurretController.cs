using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;

    // Up and down view constraints
    [SerializeField] private float minYRotation;
    [SerializeField] private float maxYRotation;
    // Left and right view constraints
    [SerializeField] private float minXRotation;
    [SerializeField] private float maxXRotation;

    // GameObjects transoforms
    [SerializeField] private Transform turretHead;
    [SerializeField] private Transform turretBase;


    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        AimTuret();
    }

    private void AimTuret()
    {
        // rotate the turret base along the x axis
        float horitzontal = Input.GetAxis("Mouse X");
        float newTurretBaseRotation = turretBase.transform.localRotation.eulerAngles.y + mouseSensitivity * horitzontal;


        // rotate the turret head along the y axis
        float vertical = Input.GetAxis("Mouse Y");
        float newTurretHeadRotation = turretHead.transform.localRotation.eulerAngles.x + mouseSensitivity * vertical;


        // limit the rotation in both axis
        //newTurretBaseRotation = Mathf.Clamp(newTurretBaseRotation, minXRotation, maxXRotation);
        //newTurretHeadRotation = Mathf.Clamp(newTurretBaseRotation, minYRotation, maxYRotation);

        // apply the rotation
        turretBase.localRotation = Quaternion.Euler(0f, newTurretBaseRotation, 0f);
        turretHead.localRotation = Quaternion.Euler(newTurretHeadRotation, 0f, 0f);

    }
}
