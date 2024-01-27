using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptingObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickableObj")
        {

        }
    }
}
