using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatDahMoneh : MonoBehaviour
{

 
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        if (other != null)
        {
            Object.Destroy(other.gameObject);
        }

    }
}