using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float state = 0;
    public float Sens = 100f;

    public Transform playerBody;

    float xRotation = 0f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Debug.Log(state);
        if (state == 0)
        {
            float mouseX = Input.GetAxis("Mouse X") * Sens * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * Sens * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            playerBody.Rotate(Vector3.up * mouseX);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            if (Input.GetKeyDown(KeyCode.P))
            {
                state = 1;

            }
        }
        else if (state == 1)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                state = 0;

            }

        }
    }
}
