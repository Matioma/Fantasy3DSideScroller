﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Range(0, 10)]
    [SerializeField]
    float speed;

    [Range(200, 1000)]
    [SerializeField]
    float jumpForce;

    [SerializeField]
    int skillDamage=10;

    [SerializeField]
    float skillCoolDown = 0.3f;
    float skillTimer;


    bool CanCastSkill {
        get { return skillTimer<=0; }
    }




    new Rigidbody rigidbody;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!CanCastSkill)
        {
            skillTimer -= Time.deltaTime;
        }
    }


    public void MoveForward() {
        Vector3 velocityY = new Vector3(0, rigidbody.velocity.y,0);
        Vector3 velocityXZplane = (new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z) + transform.forward * speed).normalized * speed;

        rigidbody.velocity = velocityXZplane+ velocityY;
    }


    public void MoveBackward() {
        Vector3 velocityY = new Vector3(0, rigidbody.velocity.y, 0);
        Vector3 velocityXZplane = (new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z) + -transform.forward * speed).normalized * speed;

        rigidbody.velocity = velocityXZplane + velocityY;
    }

    public void Jump() {
        rigidbody.AddForce(transform.up*jumpForce);        
    }


    public void CastSpell() {
        if (!CanCastSkill) return;


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            EnemyStats enemyHit = hit.transform.GetComponent<EnemyStats>();
            if (enemyHit != null)
            {
                enemyHit.Hit(skillDamage);
                SetSkillOnCooldown();
            }
        }
    }

    private void SetSkillOnCooldown()
    {
        skillTimer = skillCoolDown;
    }
}
