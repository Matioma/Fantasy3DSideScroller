using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CameraFollow))]
public class FollowingCameraEditor : Editor
{
    protected virtual void OnSceneGUI()
    {
        CameraFollow camera = target as CameraFollow;

        Vector3 center = camera.Min +  (camera.Max - camera.Min)/2;
        Vector3 size = camera.Max - camera.Min;

        Handles.color = Color.yellow;
        Handles.DrawWireCube(center, size);


        Vector3 minVector = Handles.PositionHandle(camera.Min, Quaternion.identity);
        if (minVector.x < camera.Max.x && minVector.y < camera.Max.y && minVector.z < camera.Max.z) {
            camera.Min = minVector;
        }

        Vector3 maxVector = Handles.PositionHandle(camera.Max, Quaternion.identity);
        if (maxVector.x > camera.Min.x && maxVector.y > camera.Min.y && maxVector.z > camera.Min.z)
        {
            camera.Max = maxVector;
        }
    }
}
