using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    Camera fpsCam;
    public AudioSource jumpSource;

    [Header("Movement")]
    public float currentSpeed = 0f;
    float speedVelRef;
    public float runSpeed = 8f;
    public float walkSpeed = 4f;
    public float speedSmoothTime = 0.5f;

    [Header("Crouching")]
    public float crouchSpeed = 2f;
    public float crouchSmoothTime = 0.1f;
    Vector3 crouchVelRef;

    [Header("Jumping and Ground Check")]
    public float gravity = -24.525f;
    public float jumpHeight = 1.5f;
    public AudioClip[] jumpSounds;

    public Transform groundPosition;
    public float groundDistance = 0.1f;
    public LayerMask groundLayer;

    [Header("Booleans")]
    public bool running = false;
    public bool onGround = false;
    public bool crouching = false;

    [Header("Vectors")]
    public Vector3 movement;
    public Vector3 camStandingPos;
    public Vector3 camCrouchingPos;
    Vector3 velocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        fpsCam = Camera.main;
        fpsCam.transform.localPosition = camStandingPos;
    }

    private void Update()
    {
        // check if on ground
        onGround = Physics.CheckSphere(groundPosition.position, groundDistance, groundLayer);
        if (onGround && velocity.y < 0f)
        {
            velocity.y = -2f;
            controller.stepOffset = 0.7f;
        }

        // movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        movement = transform.right * x + transform.forward * z;
        movement = Vector3.ClampMagnitude(movement, 1f);

        // crouching
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (crouching) crouching = false;
            else crouching = true;
        }

        if (crouching)
        {
            fpsCam.transform.localPosition = Vector3.SmoothDamp
                (fpsCam.transform.localPosition, camCrouchingPos, ref crouchVelRef, crouchSmoothTime);
            currentSpeed = crouchSpeed;
        }
        else fpsCam.transform.localPosition = Vector3.SmoothDamp
                (fpsCam.transform.localPosition, camStandingPos, ref crouchVelRef, crouchSmoothTime * 2f);

        // running / walking
        if (!crouching)
        {
            running = Input.GetKey(KeyCode.LeftShift);
            currentSpeed = running ? Mathf.SmoothDamp(currentSpeed, runSpeed, ref speedVelRef, speedSmoothTime * 2)
                : Mathf.SmoothDamp(currentSpeed, walkSpeed, ref speedVelRef, speedSmoothTime);
        }
        controller.Move(movement * currentSpeed * Time.deltaTime);

        // jumping and gravity
        if (Input.GetButtonDown("Jump") && onGround)
        {
            jumpSource.PlayOneShot(jumpSounds[Random.Range(0, jumpSounds.Length)]);

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            controller.stepOffset = 0f;
            crouching = false;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
