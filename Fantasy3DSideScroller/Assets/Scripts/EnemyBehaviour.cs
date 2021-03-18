using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Stats))]
//[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class EnemyBehaviour : MonoBehaviour
{
    private Stats stats;
    new private SphereCollider collider;
    Rigidbody rigidbody;


    [SerializeField]
    Transform[] possibleTargets;


    Transform target =null;

    [SerializeField]
    float Speed;
    [SerializeField]
    float detectionRange=1;

    private void Awake()
    {
        stats = GetComponent<Stats>();
        collider = GetComponent<SphereCollider>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        anyTargetInRange();
        FollowTarget();
    }


    void FollowTarget() {
        if (target == null) return;

        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(targetPosition);
        rigidbody.velocity = transform.forward * Speed;
    }

    void anyTargetInRange() {
        foreach (var atarget in possibleTargets) {
            if ((atarget.position - transform.position).sqrMagnitude <= detectionRange * detectionRange) {
                if (canSee(atarget))
                {
                    Debug.Log("Hit the palyer");
                    target = atarget;
                }
            }
        }
    }

    bool canSee(Transform ptransform) {
        RaycastHit hit;

        Vector3 vectorToTransform = ptransform.position - transform.position;


        if (Physics.Raycast(transform.position, vectorToTransform, out hit, Mathf.Infinity))
        {
            if (hit.transform == ptransform) {
                return true;
            }
        }
        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.ToLower().Trim().Equals("player"))
        {
            collision.gameObject.GetComponent<Stats>().Hit(stats.Damage);
        }
    }
}
