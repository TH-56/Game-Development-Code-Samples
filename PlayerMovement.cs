using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Initializing variables.
    [Header("Attributes:")]
    [SerializeField] private float playerSpeed;
    [HideInInspector] private Vector2 movement;
    [HideInInspector] private bool canMove;
    [HideInInspector] private bool facingRight = true;
    [HideInInspector] private bool playFootsteps = true;

    [Header("Components:")]
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private ParticleSystem footstepsParticles;
    [SerializeField] private AudioSource footstepSFX;

    // Initializing variables upon start.
    void Start()
    {
        canMove = true; 
    }

    // Handles user input.
    private void Update()
    {
        // Handling the footstep particle effect.
        if (animator.GetFloat("Speed") != 0 && canMove)
        {
            if(!footstepSFX.isPlaying && playFootsteps)
                footstepSFX.Play();

            if(!footstepsParticles.isPlaying)
                footstepsParticles.Play(true);
        }
        else
        {
            if(footstepSFX.isPlaying)
            {
                playFootsteps = false;
                footstepSFX.Stop();
                StartCoroutine(FootstepCD());
            }

            if (footstepsParticles.isPlaying)
                footstepsParticles.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
    }

    // Footstep cooldown handling.
    IEnumerator FootstepCD()
    {
        yield return new WaitForSeconds(0.25f);
        playFootsteps = true;
    }

    // Movement handling.
    void FixedUpdate()
    {
        Vector2 direction = Vector2.zero;

        if (canMove)
        {
            if(KeyBindingManager.GetKey(KeyAction.up))
            {
                direction += Vector2.up;
                animator.SetFloat("Vertical", 1f);
                animator.SetFloat("LastVertical", 1f);
                animator.SetFloat("Speed", 1f);
            }

            if(KeyBindingManager.GetKey(KeyAction.left))
            {
                direction += Vector2.left;
                animator.SetFloat("Horizontal", -1f);
                animator.SetFloat("LastHorizontal", -1f);
                animator.SetFloat("LastVertical", 0f);
                animator.SetFloat("Speed", 1f);
            }

            if(KeyBindingManager.GetKey(KeyAction.down))
            {
                direction += Vector2.down;
                animator.SetFloat("Vertical", -1f);
                animator.SetFloat("LastVertical", -1f);
                animator.SetFloat("Speed", 1f);
            }

            if(KeyBindingManager.GetKey(KeyAction.right))
            {
                direction += Vector2.right;
                animator.SetFloat("Horizontal", 1f);
                animator.SetFloat("LastHorizontal", 1f);
                animator.SetFloat("LastVertical", 0f);
                animator.SetFloat("Speed", 1f);
            }

            if(!KeyBindingManager.GetKey(KeyAction.up) && !KeyBindingManager.GetKey(KeyAction.down))
            {
                animator.SetFloat("Vertical", 0f);
            }

            if(!KeyBindingManager.GetKey(KeyAction.left) && !KeyBindingManager.GetKey(KeyAction.right))
            {
                animator.SetFloat("Horizontal", 0f);
            }

            if(!KeyBindingManager.GetKey(KeyAction.up) && !KeyBindingManager.GetKey(KeyAction.left)
                && !KeyBindingManager.GetKey(KeyAction.down) && !KeyBindingManager.GetKey(KeyAction.right))
            {
                animator.SetFloat("Vertical", 0f);
                animator.SetFloat("Horizontal", 0f);
                animator.SetFloat("Speed", 0f);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            animator.SetFloat("Speed", 0f);
        }

        transform.Translate(direction.normalized * playerSpeed * Time.deltaTime);
    }

    // Checks whether or not the player can move.
    public void CanMove(bool value)
    {
        canMove = value;
    }
}