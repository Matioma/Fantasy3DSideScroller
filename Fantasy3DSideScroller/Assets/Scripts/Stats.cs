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
    public UnityEvent onNotEnoughMana;

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
        private set
        {
            health = value;
            if (health <= 0)
            {
                health = 0;
                onDeath?.Invoke();
            }
        }
    }
    public int Mana {
        get { return mana; }
        set {
            if (value > mana) {
                onNotEnoughMana?.Invoke();
                return;
            }
            mana= value;
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
    public void UseMana(int amount) {
        Mana -= amount;
    }
}
