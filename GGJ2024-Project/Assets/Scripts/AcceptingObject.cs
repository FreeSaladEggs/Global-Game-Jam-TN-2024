using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptingObject : MonoBehaviour
{
    //public int action = 0;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            Debug.Log("in place");
            other.gameObject.layer = 0;   
            GameManager.Instance.action++;  
        }
    }

}
