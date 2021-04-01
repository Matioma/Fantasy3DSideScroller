using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParticleBehavior : MonoBehaviour
{
    [SerializeField]
    UnityEvent onPickUp;

    GameObject player;

    [SerializeField]
    float ClosingDistanceSpeed = 1;

    [SerializeField]
    float pullDistance = 15;

    [SerializeField]
    int experienceAmount=0;

    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        onPickUp.AddListener(AddExperience);
    }

    void AddExperience() {
        player.GetComponent<PlayerStats>().AddExperience(experienceAmount);
    }


    void Update()
    {
        PullToPlayer();
    }

    void PullToPlayer()
    {
        if ((player.transform.position - transform.position).sqrMagnitude >= pullDistance*pullDistance) return;

        Vector3 targetVector = (player.transform.position - transform.position).normalized;
        GetComponent<Rigidbody>().velocity+=targetVector* ClosingDistanceSpeed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            onPickUp?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
