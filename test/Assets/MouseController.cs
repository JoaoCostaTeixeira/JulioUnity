using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{

    public float mouseSens = 200f;
    public Transform playerBody;
    public Transform leftArm;
    float xRotation = 0f;
    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mousey;
        yRotation -= mouseX;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerBody.Rotate(Vector3.up * mouseX);
        Debug.Log(xRotation);
        if(xRotation != 90f && xRotation != -90f)
        {
            leftArm.Rotate(Vector3.left * mousey);
        }
       

    }
}
