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

    float Experience
    {
        get { 
            return experience; 
        }
        set { 
            experience = value;
            //Debug.Log(experience);
        }
    }

    public void AddExperience(float amount)
    {
        Experience += amount;
    }
}
