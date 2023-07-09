using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerAnimations : MonoBehaviour
{
    public Animator playerAnimator;
    private SCR_PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        controller = GetComponentInParent<SCR_PlayerController>();
        
    }
    public void FootstepAudio()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerFootstep");
    }

    void Update()
    {
        if (controller.movement.x != 0f || controller.movement.z != 0f)
        {
            playerAnimator.SetBool("IsIdle", false);
        }
        else
        {
            playerAnimator.SetBool("IsIdle", true);
        }
    }
}
