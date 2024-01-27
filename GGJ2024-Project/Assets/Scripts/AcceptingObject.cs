using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptingObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 4)
        {
            Debug.Log("gdsjk");
            other.gameObject.layer = 0;      }
    }
}
