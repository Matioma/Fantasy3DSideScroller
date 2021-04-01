using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressManager : MonoBehaviour
{
    bool savedAtLeastOnce;

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
        if (!savedAtLeastOnce) { 
            RestartLevel();
            return;        
        }
        playerStats.ResetStats(health, damage, mana);
        playerStats.transform.position = position;
    }

    public void SaveProgress() {
        health = playerStats.Health;
        mana = playerStats.Mana;
        damage = playerStats.Damage;
        position = playerStats.transform.position;
    }


    public void RestartLevel() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
