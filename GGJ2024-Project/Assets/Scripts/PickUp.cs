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
    GameObject pickableObject;
    public Transform virtualHand;
    public bool hasPickedObject = false;

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        RaycastHit[] hits = Physics.RaycastAll(ray, pickUpDistance, Pickable);


        if (!hasPickedObject && Input.GetKey(KeyCode.G))
        {
            foreach (RaycastHit hit in hits)
            {
                pickableObject = hit.collider.gameObject;
                if (pickableObject.layer == 6)
                {
                    Debug.Log("hezz object: " + pickableObject.name);
                    Pickup();
                }
            }
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
        Debug.Log("Ytayech");

    }
}
