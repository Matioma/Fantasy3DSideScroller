using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Stats))]
public class EnemyBehaviour : MonoBehaviour
{
    Stats stats;

    private void Awake()
    {
        stats = GetComponent<Stats>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.ToLower().Trim().Equals("player"))
        {
            collision.gameObject.GetComponent<Stats>().Hit(stats.Damage);
        }
    }
}
