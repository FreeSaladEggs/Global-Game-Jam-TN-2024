using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptingObject : MonoBehaviour
{
    //public int action = 0;
    

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 6)
        {
            Debug.Log("in place");
            collision.gameObject.layer = 0;   
            GameManager.Instance.action++;  
        }
    }

}
