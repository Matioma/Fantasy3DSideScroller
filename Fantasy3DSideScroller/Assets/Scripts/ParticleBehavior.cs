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

    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
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
