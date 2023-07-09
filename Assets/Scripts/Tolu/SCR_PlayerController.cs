using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerController : MonoBehaviour
{

    public Animator playerAnimator;
    public GameObject playerMesh;
    CharacterController controller;
    Vector3 movement;
    [SerializeField] float movementSpeed;
    private float gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3f;
    private float velocity;

    //[Header("TranslateSystem")]

    //[SerializeField] Vector3 origin, targetPos;
    //[SerializeField] float movementDistance = 10f;
    //[SerializeField] bool isMoving;

    public void Start()
    {
        controller = GetComponent<CharacterController>();
        playerAnimator = playerMesh.GetComponent<Animator>();
    }

    private void Update()
    {
        CryptMovement();

    }



    void CryptMovement()
    {

        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");

        ////move = transform.right * x + transform.forward * z;

        ////controller.Move(move * movementSpeed * Time.deltaTime);

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");


        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.z))
        {
            movement.z = 0;
        }
        else
        {
            movement.x = 0;
        }

        if (movement.x != 0f || movement.z != 0f)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(movement.x, 0, movement.z));
            playerAnimator.SetBool("IsIdle", false);
        }
        else
        {
            playerAnimator.SetBool("IsIdle", true);
        }

        movement.y += gravity * Time.deltaTime;
        //transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        controller.Move(movement * movementSpeed * Time.deltaTime);
    }

    //public IEnumerator MovePlayer(Vector3 dir)
    //{
    //    isMoving = true;

    //    origin = transform.position;

    //    targetPos = origin + dir;

    //    for (float i = 0f; i < movementDistance; i += Time.deltaTime)
    //    {
    //        transform.position = Vector3.MoveTowards(origin, targetPos, i);
    //        yield return null;
    //    }


    //    movementState = MovementStates.NOTHING;

    //    isMoving = false;


    //}



}
