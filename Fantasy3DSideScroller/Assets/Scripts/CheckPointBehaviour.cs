using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class CheckPointBehaviour : MonoBehaviour
{
    BoxCollider trigger;


    public UnityEvent onCheckPointEnter;
    void Start()
    {
        trigger = GetComponent<BoxCollider>();
        ValidateTrigger();
    }

    void ValidateTrigger() {
        if (!trigger.isTrigger) Debug.LogWarning("The cllider at check point should have trigger on to enablle OnTriggerEvents, setting the trigger On automatically");
        trigger.isTrigger = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() != null) {
            onCheckPointEnter?.Invoke();
            Debug.Log("Checkpoint Reached");
        }    
    }
}
