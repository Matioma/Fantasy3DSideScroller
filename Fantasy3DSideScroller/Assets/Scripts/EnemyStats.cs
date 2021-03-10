using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    float health=1;

    public UnityEvent onDeath;
    public UnityEvent onHit;

    private void Start()
    {
        onDeath.AddListener(Die);
    }


    public float Health{ get {
            return health;
        }
        set {
            Debug.Log(value);
            health = value;
            if (health < 0) {
                health = 0;
                onDeath?.Invoke();     
            }
        } 
    }


    public void Die() {
        Destroy(gameObject);
    }

    public void Hit(float damage) {
        Health -= damage;
        onHit?.Invoke();
    }
}
