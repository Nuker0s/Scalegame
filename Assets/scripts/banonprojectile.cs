using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(Rigidbody))]
public class banonprojectile : MonoBehaviour
{
    public Rigidbody rb;
    public float stun;
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
        if (explosive)
        {
            RaycastHit[] hits = Physics.SphereCastAll(collision.GetContact(0).point, range, Vector3.down);
            foreach (RaycastHit hit in hits)
            {
                Debug.Log(hit.collider.gameObject.name);
                StartCoroutine( Dealer(hit.collider.transform.gameObject));

            }
        }
        onhit.transform.parent = null;
        trail.transform.parent = null;
        onhit.Play();
        trail.Stop();
        //trail.SendEvent("stop");
        Destroy(onhit.gameObject,10);
        Destroy(trail.gameObject,10);
        Destroy(gameObject);

    }
    public IEnumerator Dealer(GameObject target)
    {
        if (target.TryGetComponent(out Enemy1 enemy))
        {
            enemy.stuntimer += 0.1f;
            
            
            enemy.Recivedamage(damage, transform.position, knockback/4, range);
            
        }
        else if (target.TryGetComponent(out Rigidbody trb))
        {
            
            trb.AddExplosionForce(knockback, transform.position, range);
        }
        yield break;
    }


}
