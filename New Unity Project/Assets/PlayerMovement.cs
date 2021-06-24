using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.8f;
    public float jumpheight = 3f;

    public Transform groundCheck;
    public float groundDistance = 2f;
    public LayerMask groundMask;
    public float state = 1;
    public Transform Text;



    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        if (state == -1)
        {
            Cursor.lockState = CursorLockMode.None;

            GameObject.Find("Text (TMP)").transform.localScale = new Vector3(1,1, 1);

            if (Input.GetKeyDown(KeyCode.P))
            {
                state = 1;

            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                state = 0;
            }
        }
        else {
            if (Input.GetKeyDown(KeyCode.P))
            {
                state = -1;
            }
            GameObject.Find("Text (TMP)").transform.localScale = new Vector3(0, 0, 0);
            Cursor.lockState = CursorLockMode.Locked;
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }

    }
}
