using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerController : MonoBehaviour
{
    CharacterController controller;
    [SerializeField] float movementDistance= 10f;
    [SerializeField] float movementInterval = 0.5f;
    [SerializeField] float jumpHeight;
    Vector3 move;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    public bool isGrounded;

    public float airTime = 0.1f;

    public float gravity = -10f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        CryptMovement();

    }

    void CryptMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        controller.Move(move * movementDistance * Time.deltaTime);
    }

    void CryptJump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y <= 0)
        {
            airTime = 0.1f;
            velocity.y = -2f;

        }

        if (!isGrounded) airTime -= Time.deltaTime;


        if (airTime <= 0f) velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

}
