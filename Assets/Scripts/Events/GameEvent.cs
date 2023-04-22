using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameEvent : MonoBehaviour
{
    public GameObject alvo;
    public NavMeshAgent a;
    public float targetThreshold = 15f; // adjust this value to change the distance threshold


    private Animator animator; // Declare the Animator field

    private void Start()
    {
        animator = GetComponent<Animator>(); // Initialize the Animator field
    }

    private bool hasTarget = false;

    void Update()
{
    float distanceToTarget = Vector3.Distance(transform.position, alvo.transform.position);

    if (!hasTarget && distanceToTarget <= targetThreshold)
    {
        a.SetDestination(alvo.transform.position);
        hasTarget = true;
        animator.Play("run_motion");
        animator.SetBool("Aware", true);
    }
    else if (hasTarget && distanceToTarget > targetThreshold)
    {
        a.ResetPath();
        hasTarget = false;
        animator.Play("idly_motion");
        animator.SetBool("Aware", false);
    }
    else if (hasTarget && distanceToTarget <= targetThreshold)
    {
        a.SetDestination(alvo.transform.position);
    }
}

    public void tes()
    {
        Debug.Log("rer");
    }
}