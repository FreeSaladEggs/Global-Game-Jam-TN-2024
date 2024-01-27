using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    float pickUpDistance = 2f;
    Ray ray;
    public LayerMask Pickable;
    public GameObject pickableObject ;
    public Transform virtualHand;
    public bool hasPickedObject = false;

    // Update is called once per frame
    void Update()
    {
        RaycastHit[] hits = Physics.RaycastAll(ray, pickUpDistance, Pickable);
        ray = new Ray(transform.position, transform.forward);
        
            foreach (RaycastHit hit in hits)
            {
                
                pickableObject = hit.collider.gameObject;

                
                Debug.Log("hezz object: " + pickableObject.name);
            }
            if (!hasPickedObject && Input.GetKey(KeyCode.G)) 
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
