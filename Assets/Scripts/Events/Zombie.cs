using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class Zombie : MonoBehaviour
{
    public GameObject alvo;
    public NavMeshAgent agent;
    public float targetThreshold = 15f; // adjust this value to change the distance threshold

    public float speed = 1;
    private Animator animator; // Declare the Animator field
    public bool attack;
    private void Start()
    {
        animator = GetComponent<Animator>(); // Initialize the Animator field
    }

    private bool hasTarget = false;

    void Update()
    {


    float distanceToTarget = Vector3.Distance(transform.position, alvo.transform.position);
    if (attack)
        return;
    if (!hasTarget && distanceToTarget <= targetThreshold)
    {
        agent.SetDestination(alvo.transform.position);
        hasTarget = true;
        //animator.Play("run_motion");
        animator.SetBool("Aware", true);
        animator.SetBool("Attack", false);
        animator.speed = speed;
    }
    else if (hasTarget && distanceToTarget > targetThreshold)
    {
        agent.ResetPath();
        hasTarget = false;
        //animator.Play("idly_motion");
        animator.SetBool("Aware", false);
        animator.SetBool("Attack", false);
        animator.speed = 1;
    }
    else if (hasTarget && distanceToTarget <= targetThreshold)
    {
        animator.SetBool("Aware", true);
        agent.SetDestination(alvo.transform.position);
    }
}

    public void tes()
    {
        Debug.Log("rer");
    }

    private void OnTriggerExit(Collider other)
    {
        
        Debug.Log("tes");
        if (other.gameObject.tag.Equals("Player"))
        {
            attack = false;
            animator.SetBool("Attack", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            attack = true;
            animator.SetBool("Attack", true);
            animator.SetBool("Aware", false);
        }
    }
}