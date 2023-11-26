using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagable : MonoBehaviour
{
    public Enemy1 todamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ReciveDamage(float damage, Vector3 from, float force, float range) 
    {
        todamage.Recivedamage(damage, from, force, range);
    }
}
