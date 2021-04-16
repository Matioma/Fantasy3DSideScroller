using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{
    [SerializeField]
    int health = 1;
    [SerializeField]
    int damage = 1;

    public int Damage { get { return damage; } private set{ damage = value; } }

    [SerializeField]
    int mana;

    public UnityEvent onDeath;
    public UnityEvent onHit;
    public UnityEvent onNotEnoughMana;

    protected void Awake()
    {
    }
    private void Start()
    {
    }


    public virtual void UpdateStats(PlayerStateStats stats) {
        health = stats.health;
        damage = stats.damage;
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
        private set {
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


    public void ResetStats(int health, int damage, int mana) {
        Health = health;
        Damage = damage;
        Mana = mana;
    }
}
