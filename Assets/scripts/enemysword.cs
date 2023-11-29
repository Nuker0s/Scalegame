using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemysword : MonoBehaviour
{
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerManager pm))
        {
            pm.Recivedamage(damage);
        }
    }
}
