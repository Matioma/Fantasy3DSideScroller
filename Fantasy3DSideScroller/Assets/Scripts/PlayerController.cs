using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    PlayerMovement playerMovement;
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }



    private void Update()
    {
        if (Input.GetKey(KeyCode.D)) {
            playerMovement.MoveForward();
        }

        if (Input.GetKey(KeyCode.A)) {
            playerMovement.MoveBackward();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            playerMovement.Jump();
        }


        if (Input.GetMouseButtonDown(0)) {
            playerMovement.CastSpell();
        }
    }
}
