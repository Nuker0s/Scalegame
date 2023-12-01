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
    public Vector3 PlayerPos;
    public float visiondistance;
    public float attackdistance;
    public Rigidbody rb;
    public bool isterrain = true;
    public float stuntimer;
    public float rottimer;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("player").transform;
        if (isterrain)
        {
            Destroy(agent);
        }
        if (breakable==null)
        {
            TryGetComponent(out breakable);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isterrain)
        {
            try
            {
                movement();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        

    }
    public void Recivedamage(float damage, Vector3 from, float force, float range)
    {
        health -= damage;

        
        if (health <= 0)
        {
            breakable.breaking(from, force / 8, range);
        }
        //wait
        if (!isterrain)
        {
            rb.AddForce((transform.position - from).normalized * force);
        }
        
    }

    public void movement()
    {
        //Debug.Log(agent.isOnNavMesh);

        if ((agent.isOnNavMesh || agent.isOnOffMeshLink) && stuntimer <= 0 && Vector3.Distance(transform.position, Player.position) <= visiondistance)
        {
            rb.isKinematic = true;
            agent.enabled = true;
            if (PlayerPos != Player.position)
            {
                agent.destination = Player.position;
                PlayerPos = Player.position;
            }
            

            if (Vector3.Distance(transform.position, Player.position) <= attackdistance)
            {
                anim.button = true;
                agent.isStopped = true;
                transform.rotation = math.slerp(transform.rotation,quaternion.LookRotation(Player.position - transform.position, Vector3.up),rottimer);
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
                        agent.destination = Player.position;
                        PlayerPos = Player.position;
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
