using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExitBehaviour : MonoBehaviour
{
    public UnityEvent onLevelPassed;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.ToLower().Equals("player")) {
            onLevelPassed?.Invoke();
        }
    }
}
