/*
Copyright 2023 Om Rawaley (@omrawaley)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody rb;
    public Camera cam;
    public Transform groundCheck;

    private float horizontalMovement;
    private float verticalMovement;

    private float horizontalMouse;
    private float verticalMouse;

    [Header("Speed")]
    public float movementSpeed;

    public float cameraXSpeed;
    public float cameraYSpeed;

    [Header("Jumping")]
    public bool enableJumping;

    public float thrust;

    [SerializeField]bool grounded;

    [Header("Camera Limit")]
    private float minTurnAngle = -90.0f;
	private float maxTurnAngle = 90.0f;

    [Header("Input Smoothing")]
    public bool useInputSmoothing;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb.freezeRotation = true;
    }

    void Update()
    {
        Camera();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if(useInputSmoothing)
        {
            horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
            verticalMovement = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime; 
        }
        else
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime;
            verticalMovement = Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime;
        }

        Vector3 move = new Vector3(horizontalMovement, 0, verticalMovement);

        rb.AddRelativeForce(move, ForceMode.Force);

        Jump();
    }

    void Jump()
    {
        if(!enableJumping)
            return;

        grounded = Physics.Raycast(groundCheck.position, Vector3.down, 0.5f);

        if(Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

            rb.AddRelativeForce(transform.up * thrust * Time.deltaTime, ForceMode.Force);

            grounded = false;
        }
    }

    void Camera()
    {
        if(useInputSmoothing)
        {
            horizontalMouse += Input.GetAxis("Mouse X") * cameraXSpeed * Time.deltaTime;
            verticalMouse += Input.GetAxis("Mouse Y") * cameraXSpeed * Time.deltaTime;
        }
        else
        {
            horizontalMouse += Input.GetAxisRaw("Mouse X") * cameraYSpeed * Time.deltaTime;
            verticalMouse += Input.GetAxisRaw("Mouse Y") * cameraYSpeed * Time.deltaTime;
        }

        verticalMouse = Mathf.Clamp(verticalMouse, minTurnAngle, maxTurnAngle); 

        transform.eulerAngles = new Vector3(0, horizontalMouse, 0);
        cam.transform.eulerAngles = new Vector3(-verticalMouse, horizontalMouse, 0);
    }
}
