using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float health;
    public float maxhealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Recivedamage(float damage) 
    {
        health -= damage;
        if (health < 0)
        {
            Debug.Log("dead");
        }
    }
}
