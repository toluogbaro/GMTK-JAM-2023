using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerController : MonoBehaviour
{

    CharacterController controller;
    Vector3 move;
    [SerializeField] float movementSpeed;
    //[Header("TranslateSystem")]

    //[SerializeField] Vector3 origin, targetPos;
    //[SerializeField] float movementDistance = 10f;
    //[SerializeField] bool isMoving;

    public void Start()
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

        //move = transform.right * x + transform.forward * z;

        //controller.Move(move * movementSpeed * Time.deltaTime);

        Vector3 movement = new Vector3(x, 0.0f, z);
        if (x != 0f || z != 0f)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }


        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
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
