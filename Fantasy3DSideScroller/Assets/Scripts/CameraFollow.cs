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


    [Header("Camera level Boundries")]
    [SerializeField]
    Vector3 minLevelBoundries;
    public Vector3 Min
    {
        get { return minLevelBoundries; }
        set { minLevelBoundries = value; }
    }
    
    [SerializeField]
    Vector3 maxLevelBoundries;
    public Vector3 Max {
        get { return maxLevelBoundries; }
        set { maxLevelBoundries = value; }
    }

    void Start()
    {
        offset = transform.position - target.position;
        
    }

    private void FixedUpdate()
    {
        if (CameraInLevelBoundries()) { 
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y+ offset.y, transform.position.z) ;
            transform.position = Vector3.Lerp(transform.position, targetPosition, rate);
        }
    }


    bool CameraInLevelBoundries() {
        Vector3 position = transform.position;

        bool inBoundries = position.x > Min.x && position.x < Max.x &&
                           position.y > Min.y && position.y < Max.y &&
                           position.z > Min.z && position.z < Max.z;
        Debug.Log(inBoundries);
        return true;
    }
}
