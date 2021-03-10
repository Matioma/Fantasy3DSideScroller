using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Range(0, 10)]
    [SerializeField]
    float speed;

    [Range(200, 1000)]
    [SerializeField]
    float jumpForce;


    Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    public void MoveForward() {
        Vector3 velocityY = new Vector3(0, rigidbody.velocity.y,0);
        Vector3 velocityXZplane = (new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z) + transform.forward * speed).normalized * speed;

        rigidbody.velocity = velocityXZplane+ velocityY;
    }


    public void MoveBackward() {
        Vector3 velocityY = new Vector3(0, rigidbody.velocity.y, 0);
        Vector3 velocityXZplane = (new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z) + -transform.forward * speed).normalized * speed;

        rigidbody.velocity = velocityXZplane + velocityY;
    }

    public void Jump() {
        rigidbody.AddForce(transform.up*jumpForce);        
    }

}
