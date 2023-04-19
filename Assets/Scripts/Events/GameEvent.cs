using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameEvent : MonoBehaviour
{
    public GameObject alvo;

    public NavMeshAgent a;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        a.SetDestination(alvo.transform.position);
    }


    public void tes()
    {
        Debug.Log("rer");
    }
    
}
