using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{

    public List<GameObject> tes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tes" +  other.gameObject.tag);
        if (other.gameObject.tag.Equals("Zombie"))
        {
            Debug.Log("add");
            tes.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Zombie"))
        {
            Debug.Log("remove");
            tes.Remove(other.gameObject);
        }
    }
}
