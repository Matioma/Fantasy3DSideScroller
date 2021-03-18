using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Stats))]
[RequireComponent(typeof(SphereCollider))]
public class EnemyBehaviour : MonoBehaviour
{
    private Stats stats;
    private SphereCollider collider;


    Transform target =null;

    [SerializeField]
    float detectionRange=1;

    private void Awake()
    {
        stats = GetComponent<Stats>();
        collider = GetComponent<SphereCollider>();
        ValidateSphereCollider();
    }

    private void ValidateSphereCollider() {
        if (!collider.isTrigger) Debug.LogWarning("Sphere collider in enemy behvaiour should be trigger to call onTriggerEvents");

        collider.radius = detectionRange;
    }



    private void Update()
    {
            
    }


    void FollowTarget() {
        if (target == null) return;



       
    }

    private void OnTriggerStay(Collider other)
    {
        if (target != null) return;
        if (other.gameObject.tag.Equals("Player"))
        {
            if (canSee(other.transform)) {
                Debug.Log("Hit the palyer");
                target = other.transform;
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
