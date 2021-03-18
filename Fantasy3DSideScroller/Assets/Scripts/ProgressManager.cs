using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    Vector3 position;
    int health;
    int mana;
    int damage;

    Stats playerStats;


    private void Start()
    {
        playerStats =FindObjectOfType<PlayerMovement>().GetComponent<Stats>();
    }


    public void LoadProgress()
    {
        playerStats.ResetStats(health, damage, mana);
        playerStats.transform.position = position;
    }

    public void SaveProgress() {
        health = playerStats.Health;
        mana = playerStats.Mana;
        damage = playerStats.Damage;
        position = playerStats.transform.position;
    }
}
