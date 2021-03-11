using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{
    [SerializeField]
    int health=1;
    [SerializeField]
    int damage=1;

    public int Damage { get { return damage; } }

    [SerializeField]
    int mana;


    public UnityEvent onDeath;
    public UnityEvent onHit;

    private void Start()
    {
        onDeath.AddListener(Die);
    }

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            if (health <= 0)
            {
                health = 0;
                onDeath?.Invoke();
            }
        }
    }


    public void Die()
    {
        Destroy(gameObject);
    }

    public void Hit(int damage)
    {
        Health -= damage;
        onHit?.Invoke();
    }

}
