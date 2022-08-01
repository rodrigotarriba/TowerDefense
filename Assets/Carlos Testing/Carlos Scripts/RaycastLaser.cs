using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class RaycastLaser : MonoBehaviour
{
    [SerializeField] private Camera turretPOV;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float laserRange = 50f;
    [SerializeField] private float laserDuration = 0.05f;
    private float fireRate = 0.2f;

    LineRenderer laserLine;
    private float fireTimer;

    private void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        fireTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && fireTimer > fireRate)
        {
            laserLine.SetPosition(0, firePoint.position);
            Vector3 rayOrigin = turretPOV.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;
            if(Physics.Raycast(rayOrigin, turretPOV.transform.forward, out hit, laserRange))
            {
                laserLine.SetPosition(1, hit.point);
                Destroy(hit.transform.gameObject);
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (turretPOV.transform.forward * laserRange));
            }
            StartCoroutine(ShootLaser());
            fireTimer = 0f;
        }
       
    }

    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }
}
