using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    float pickUpDistance = 2f;
    Ray ray; 
    public GameObject pickableObject ;
    public Transform virtualHand;
    public bool hasPickedObject = false;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit , pickUpDistance) && Input.GetKey(KeyCode.G) && (!hasPickedObject))
        {
            Pickup();
        }
    }

    private void Pickup()
    {  
        pickableObject.GetComponent<Rigidbody>().isKinematic = true;
        hasPickedObject = true;
        pickableObject.transform.SetParent(virtualHand);
        pickableObject.transform.localPosition = Vector3.zero;
    }
   
}
