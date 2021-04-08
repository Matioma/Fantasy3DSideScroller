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

    private void Awake()
    {
        base.Awake();

        ProgressManager progressManager = FindObjectOfType<ProgressManager>();
        if (progressManager == null) { 
            Debug.LogWarning("The scene does not have any progress manager, it is required for saving progress/restarting level"); 
        }else { 
            onDeath.AddListener(FindObjectOfType<ProgressManager>().LoadProgress); 
        }
    }

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
