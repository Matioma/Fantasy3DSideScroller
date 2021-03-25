using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : Stats
{
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
        }
    }

    
    


}
