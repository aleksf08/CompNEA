using UnityEngine;

public class MouseMovement : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    float xRotation = 0f;
    float yRotation = 0f;

    public float topClamp = -90f;
    public float bottomClamp = 90f;
    
    void Start()
    {
        //Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        //Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Rotate around the x axis (looking up and down)
        xRotation -= mouseY;

        //Clamp the x rotation to prevent flipping
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        //Rotate around the y axis (looking left and right)
        yRotation += mouseX;

        //Apply rotations
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
