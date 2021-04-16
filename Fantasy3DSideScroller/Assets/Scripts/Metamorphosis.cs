using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
[RequireComponent(typeof(PlayerMovement))]
public class Metamorphosis : MonoBehaviour
{
    [SerializeField]
    PlayerStateStats[] States;


    PlayerStats stats;
    PlayerMovement playerMovement;



    int stateIndex=0;


    private void Awake()
    {
        stats = GetComponent<PlayerStats>();
        playerMovement = GetComponent<PlayerMovement>();

    }



    void Start()
    {
        
    }
    public void switchState()
    {
        stateIndex = (stateIndex + 1) % States.Length;
        stats.UpdateStats(States[stateIndex]);
        playerMovement.UpdateStats(States[stateIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
