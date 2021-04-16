using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    [SerializeField]
    GameObject victoryScreen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShowVictoryScreen()
    {
        victoryScreen.SetActive(true);
    }
}
