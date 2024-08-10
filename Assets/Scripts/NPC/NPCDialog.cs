using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;

    void FixedUpdate()
    {
        DetectPlayer();        
    }

    private void DetectPlayer() { 
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if (hit != null) {
            Debug.Log("Player na área de contato");
        }
    }


    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }


}
