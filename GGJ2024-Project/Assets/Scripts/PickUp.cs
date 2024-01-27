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
        if (Physics.Raycast(ray, out hit , pickUpDistance) && Input.GetKeyDown(KeyCode.G) && !hasPickedObject)
        {
            Pickup();
        }
        if (hasPickedObject && (Input.GetKeyDown(KeyCode.V)))
        {
            Drop();
        }

    }

    private void Pickup()
    {  
        pickableObject.GetComponent<Rigidbody>().isKinematic = true;
        pickableObject.transform.SetParent(virtualHand);
        pickableObject.transform.localPosition = Vector3.zero;
        hasPickedObject = true;
    }
    private void Drop()
    {
        pickableObject.GetComponent<Rigidbody>().isKinematic = false;
        pickableObject.transform.SetParent(null);
        pickableObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 10, ForceMode.Acceleration);
        hasPickedObject = false;

    }


}
