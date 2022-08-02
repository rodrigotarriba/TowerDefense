using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rotates player on its axis depending on mouse axis input
/// </summary>

//rtcNote this class pertains only to FPS - should be addressed appropiately

public class PlayerRotation : MonoBehaviour
{

    private float mouseX;
    private float mouseY;
    private float yRotation = 0f;


    public float mouseSensitivity = 100f;

    public Transform playerBody;

    

    // Start is called before the first frame update
    void Start()
    {
        //Lock cursor in the middle while in play mode
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        //rotate y
        transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);

        //rotate x
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
