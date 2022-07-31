using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPOV : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;

    public Transform turretHead;
    private Transform turretBeginPosition;

    private bool mouseEngaged = false;
    //private float upDownRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        turretBeginPosition = turretHead;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) == true)
        {
            mouseEngaged = true;
        }
        if(mouseEngaged == false) { return; }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mouseEngaged = false;
        }
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        gameObject.transform.Rotate(Vector3.forward, mouseX);
        turretHead.Rotate(Vector3.up, mouseY);
 
                
    }
}
