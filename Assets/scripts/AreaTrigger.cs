/////////////////////////////////////////////////////////
//
// Copyright (c) 2025 by arwasairl
//
// This source is provided under the MIT license.
// This software is provided WITHOUT A WARRANTY.
//
// WHAT:Player detection on an area
// DEFINED EXTERNS: 0
// RETURNS: 0
//
/////////////////////////////////////////////////////////

using System;
using System.Collections;
using UnityEngine;

public class XRTriggerZone : MonoBehaviour
{
    public GameObject areaTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch(areaTrigger.name)
            {
                case "Area1":
                    Debug.Log("Entered: " + areaTrigger.name);
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("XR Player exited the trigger zone.");
        }
    }
}