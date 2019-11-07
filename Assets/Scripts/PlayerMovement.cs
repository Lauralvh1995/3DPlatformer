using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform graphicsTransform;
    public Transform groundCheck;

    public float movementSpeed = 3f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;

    public float groundDistance = 0.2f;

    public LayerMask groundMask;

    public Animator m_Animator;

    Vector3 velocity;
    bool isGrounded;
    Vector3 move;
    Vector3 lastLookDirection;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        move = new Vector3(x, 0f, y).normalized * movementSpeed * Time.deltaTime;
        move = Quaternion.Euler(0, 45, 0) * move;
        if(x != 0f || y != 0f)
        {
            lastLookDirection = move;
        }
        

        controller.Move(move);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y = velocity.y + gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        UpdateAnimator(move);
    }

    void UpdateAnimator(Vector3 move)
    {
        graphicsTransform.position = transform.position;
        graphicsTransform.rotation = Quaternion.LookRotation(lastLookDirection);
        // update the animator parameters
        m_Animator.SetFloat("Forward", move.magnitude * movementSpeed *2f, 0.1f, Time.deltaTime);
        m_Animator.SetFloat("Turn", 0f, 0.1f, Time.deltaTime);
        //m_Animator.SetBool("Crouch", m_Crouching);
        m_Animator.SetBool("OnGround", isGrounded);
        if (!isGrounded)
        {
            m_Animator.SetFloat("Jump", velocity.y);
        }

        // calculate which leg is behind, so as to leave that leg trailing in the jump animation
        // (This code is reliant on the specific run cycle offset in our animations,
        // and assumes one leg passes the other at the normalized clip times of 0.0 and 0.5)
        float runCycle =
            Mathf.Repeat(
                m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime + 0.2f, 1);
        float jumpLeg = (runCycle < 0.5f ? 1 : -1) * move.magnitude;
        if (isGrounded)
        {
            m_Animator.SetFloat("JumpLeg", jumpLeg);
        }

        // the anim speed multiplier allows the overall speed of walking/running to be tweaked in the inspector,
        // which affects the movement speed because of the root motion.
        if (isGrounded && move.magnitude > 0)
        {
            m_Animator.speed = 1f;
        }
        else
        {
            // don't use that while airborne
            m_Animator.speed = 1f;
        }
    }
}
