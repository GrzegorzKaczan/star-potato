using UnityEngine;
using System;
using System.Collections.Generic; 

public class InteractableTargetController : MonoBehaviour 
{
    private void Start() {
        
    }

    public Vector3 GetTargetPosition() {
        return transform.position;
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 0, 0, 1F);
        Gizmos.DrawSphere(transform.position + Vector3.forward, 0.2f);
    }
}