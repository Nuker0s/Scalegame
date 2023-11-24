using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
{
    public float maxhp;
    public float health;
    public float damage;
    public simpleanim anim;
    public breakable breakable;
    public NavMeshAgent agent;
    public Transform Player;
    public float visiondistance;
    public float attackdistance;
    public Rigidbody rb;
    public float stuntimer;
    public Transform debugdamager;
    public Vector3 debugdamagestats;
    public bool applydebugdamage;
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if((agent.isOnNavMesh || agent.isOnOffMeshLink) || stuntimer <= 0)
        {
            rb.isKinematic = true;
            agent.enabled = true;
            agent.destination = Player.position;

            if (Vector3.Distance(transform.position,Player.position)<=attackdistance)
            {
                anim.button = true;
            }

        }
        else
        {
            rb.isKinematic = false; 
            agent.enabled = false;
        }
        if (applydebugdamage)
        {
            applydebugdamage = false;
            Recivedamage(debugdamagestats.x, debugdamager.position, debugdamagestats.x, debugdamagestats.z);
        }
    }
    public void Recivedamage(float damage, Vector3 from, float force,float range) 
    {
        health -= damage;
        if (health <= 0)
        {
            breakable.breaking(from, force, range);
        }
    }
}
