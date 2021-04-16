using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : Stats
{
    [SerializeField]
    UnityEvent onLevelUp;

    [SerializeField]
    float nextLevelExperience;
    [SerializeField]
    float experience;



    ProgressManager _progressManager;


    private void Awake()
    {
        base.Awake();

      
    }

    public override void UpdateStats(PlayerStateStats stats)
    {
        base.UpdateStats(stats);
    }

    float Experience
    {
        get { 
            return experience; 
        }
        set { 
            experience = value;
        }
    }

    public void AddExperience(float amount)
    {
        Experience += amount;
    }

}
