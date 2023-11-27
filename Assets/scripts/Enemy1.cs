using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
    public bool isterrain = true;
    public float stuntimer;
    public Transform debugdamager;
    public Vector3 debugdamagestats;
    public bool applydebugdamage;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("player").transform;
        if (isterrain)
        {
            Destroy(agent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isterrain)
        {
            movement();
        }
        
        /*if (applydebugdamage)
        {
            applydebugdamage = false;
            Recivedamage(debugdamagestats.x, debugdamager.position, debugdamagestats.y, debugdamagestats.z);
        }*/
    }
    public void Recivedamage(float damage, Vector3 from, float force,float range) 
    {
        health -= damage;
        
        if (health <= 0)
        {
            breakable.breaking(from, force, range);
        }
        
        rb.AddForce((transform.position - from).normalized * force);
        
    }
    public void movement()
    {
        //Debug.Log(agent.isOnNavMesh);

        if ((agent.isOnNavMesh || agent.isOnOffMeshLink) && stuntimer <= 0)
        {
            rb.isKinematic = true;
            agent.enabled = true;

            agent.destination = Player.position;

            if (Vector3.Distance(transform.position, Player.position) <= attackdistance && math.abs(Vector3.Dot(transform.forward, (Player.position - transform.position).normalized)) > 0.6)
            {
                anim.button = true;
                agent.isStopped = true;
            }
            else
            {
                agent.isStopped = false;
            }

        }
        else
        {
            rb.isKinematic = false;
            agent.enabled = false;
            if (stuntimer > 0)
            {
                stuntimer -= Time.deltaTime;
            }
            if (stuntimer <= 0)
            {
                try
                {

                    if (rb.velocity.magnitude > 0.5f)
                    {
                        agent.enabled = false;
                        rb.isKinematic = false;
                    }
                    else
                    {
                        agent.enabled = true;
                        rb.isKinematic = true;
                    }

                }
                catch (Exception)
                {
                    throw;
                }



            }
            if (agent.isActiveAndEnabled)
            {
                agent.isStopped = true;
            }


        }
    }
}
