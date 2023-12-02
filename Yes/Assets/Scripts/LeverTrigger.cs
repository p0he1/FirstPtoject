using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    private Animator animator;
    public Animator aniBridge;
    public Animator aniPlatform;

    public bool playerInside;
    public bool isActivated;

    public KeyCode interactKey;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public enum Move{
        Block,
        Bridge
    }

    public Move move;

    private void Update()
    {
        if (move == Move.Bridge)
        {
            if (Input.GetKeyDown(interactKey) && playerInside)
            {
                if (isActivated)
                {
                    aniBridge.Play("NonActivated");
                    animator.Play("NonActivated");
                    isActivated = false;
                }
                else
                {
                    aniBridge.Play("Activated");
                    animator.Play("Activated");
                    isActivated = true;
                }
            }
        }

        if(move == Move.Block)
        {
            if (Input.GetKeyDown(interactKey) && playerInside)
            {
                if (isActivated)
                {
                    aniPlatform.Play("Right");
                    animator.Play("NonActivated");
                    isActivated = false;
                }
                else
                {
                    aniPlatform.Play("Left");
                    animator.Play("Activated");
                    isActivated = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInside = false;
        }
    }
}
