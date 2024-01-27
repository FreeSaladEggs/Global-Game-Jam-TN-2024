using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptingObject : MonoBehaviour
{
    public bool inPlace;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 4)
        {
            other.gameObject.layer = 0;
            inPlace = true;  
        }
    }

   
}
