using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehavior : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    float ClosingDistanceForce = 100;

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
        GetComponent<Rigidbody>().velocity+=targetVector*1;
    }
}
