using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEffect : MonoBehaviour
{
    //public int Damage{ get; set; } =1;

    Stats stats;
    public void Awake()
    {
        stats = GetComponentInParent<Stats>();
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.ToLower().Trim().Equals("enemy"))
        {
            EnemyStats enemy = other.gameObject.GetComponent<EnemyStats>();

            if (enemy != null) enemy.Hit(stats.Damage);
        }
      
    }

}
