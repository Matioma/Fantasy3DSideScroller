using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerStateStats", menuName = "ScriptableObjects/PlayerStateStats", order = 1)]
public class PlayerStateStats : ScriptableObject
{
    [Header("Stats")]
    public int health = 1;
    public int damage = 1;


    [Header("Movement")]
    public int speed = 1;
    public int jumpForce = 700;

}
