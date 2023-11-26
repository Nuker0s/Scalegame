using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(Rigidbody))]
public class banonprojectile : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float damage;
    public float knockback;
    public float range;
    public bool explosive;
    public VisualEffect onhit;
    public VisualEffect trail;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject,10);
        onhit.Stop();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.gameObject.name);
        
        onhit.transform.parent = null;
        trail.transform.parent = null;
        onhit.Play();
        Destroy(onhit.gameObject,10);
        Destroy(trail.gameObject,10);
        Destroy(gameObject);

    }

}
