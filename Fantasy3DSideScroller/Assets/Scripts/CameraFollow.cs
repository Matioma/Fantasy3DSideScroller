using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [Range(0,1)]
    [SerializeField]
    float rate=1;


    Vector3 offset;

    
    void Start()
    {
        offset = transform.position - target.position;
        
    }


    private void FixedUpdate()
    {

        Vector3 targetPosition = new Vector3(target.position.x, target.position.y+ offset.y, transform.position.z) ;
        transform.position = Vector3.Lerp(transform.position, targetPosition, rate);    
    }




}
