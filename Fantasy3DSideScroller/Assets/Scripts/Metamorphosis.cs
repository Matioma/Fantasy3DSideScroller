using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerStats))]
[RequireComponent(typeof(PlayerMovement))]
public class Metamorphosis : MonoBehaviour
{
    [SerializeField]
    PlayerStateStats[] States;
    [SerializeField]
    GameObject[] prefabs;


    PlayerStats stats;
    PlayerMovement playerMovement;


    public UnityEvent onSwitchState;


    int stateIndex=0;


    private void Awake()
    {
        stats = GetComponent<PlayerStats>();
        playerMovement = GetComponent<PlayerMovement>();

        stats.UpdateStats(States[stateIndex]);
        playerMovement.UpdateStats(States[stateIndex]);
    }



    void Start()
    {
        
    }
    public void switchState()
    {
        prefabs[stateIndex].SetActive(false);
        onSwitchState?.Invoke();

        stateIndex = (stateIndex + 1) % States.Length;
        stats.UpdateStats(States[stateIndex]);
        playerMovement.UpdateStats(States[stateIndex]);
        prefabs[stateIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
