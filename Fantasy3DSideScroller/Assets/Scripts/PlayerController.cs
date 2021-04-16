using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    PlayerMovement playerMovement;

    Metamorphosis metamorphosis;
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        metamorphosis = GetComponent<Metamorphosis>();
    }



    private void Update()
    {
        if (Input.GetKey(KeyCode.D)) {
            playerMovement.MoveRight();
        }

        if (Input.GetKey(KeyCode.A)) {
            playerMovement.MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            playerMovement.Jump();
        }


        if (Input.GetMouseButtonDown(0)) {
            playerMovement.CastSpell();
        }

        if (Input.GetKeyDown(KeyCode.F)) {
            playerMovement.Attack();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            metamorphosis?.switchState();
        }
    }
}
