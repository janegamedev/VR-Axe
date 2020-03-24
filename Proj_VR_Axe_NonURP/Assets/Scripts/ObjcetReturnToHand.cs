using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ObjcetReturnToHand : MonoBehaviour
{
    public GameObject target;
    public SteamVR_Action_Boolean retractAction;
    private Rigidbody rb;

    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = FindObjectOfType<Hand>().gameObject;

    }

    private void Update()
    {
        ReturnToHand();
    }

    public void ReturnToHand()
    {
        if (retractAction[SteamVR_Input_Sources.RightHand].state)
        {
            Debug.Log("BOOP");

            var dir = target.transform.position - transform.position;
            //rb.velocity = Vector3.zero;
            rb.AddForce(dir.normalized * speed * Time.deltaTime);
            
            
        }
    }
}
