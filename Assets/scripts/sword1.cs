using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;
using UnityEngine.VFX;

public class sword1 : MonoBehaviour
{
    public float damage;
    public float knockback;
    public float stun;
    public Vector4 swordbox;
    public float maxrange;
    public bool debug;
    public Transform swordtip;
    public Vector2 slashsize;
    public float cooldownTime;
    public bool isCooldown = false;
    //public bool side = false;
    public PlayerInput pinput;
    public InputAction fire;
    public VisualEffect trail;
    public AudioClip swingsound;
    // Start is called before the first frame update
    void Start()
    {
        fire = pinput.actions.FindAction("Fire");
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (!isCooldown && fire.WasPressedThisFrame())
        {
            StartCoroutine(Attack());
        }

    }
    IEnumerator Attack()
    {


        slashsize.x *= -1;
        Vector3 startpos = swordtip.localPosition;
        Vector3 endpos =  transform.right * slashsize.x + transform.up * slashsize.y * UnityEngine.Random.Range(-1f, 1f);
        swordtip.position = transform.position + endpos;
        //float journeyTime = slashtime; // Time taken to move from startpos to endpos
        RaycastHit[] hits = Physics.BoxCastAll(transform.position + transform.forward * swordbox.w,new Vector3(swordbox.x,swordbox.y,swordbox.z),transform.forward,Quaternion.LookRotation(transform.forward),maxrange);
        foreach (RaycastHit hit in hits)
        {
            //Debug.Log(hit.collider.gameObject.name);
            StartCoroutine(Dealer(hit.collider.transform.gameObject));

        }
        //StartCoroutine(Dealer());
        trail.SetVector3("start", startpos);
        trail.SetVector3 ("end", swordtip.localPosition);
        trail.Play();
        onesound.playsound(swordtip.position, swingsound, globalvariables.sfxvolume);
        isCooldown = true;
        /*
        while (elapsedTime < journeyTime)
        {
            swordtip.position = Vector3.Lerp(startpos,  endpos, (elapsedTime / journeyTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        trail.transform.position = swordtip.position;*/
        

         // Ensure the final position is endpos
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }
    public IEnumerator Dealer(GameObject target)
    {
        if (target.TryGetComponent(out Enemy1 enemy))
        {
            enemy.stuntimer += stun;
            yield return new WaitForFixedUpdate();
            enemy.Recivedamage(damage, transform.parent.position, knockback, 0);


        }
        else if (target.TryGetComponent(out Rigidbody trb))
        {

            trb.AddForce((trb.position - transform.position).normalized * knockback);
        }
        yield break;
    }
    private void OnDrawGizmos()
    {
        if (debug)
        {
            Gizmos.color = Color.yellow;
            
            Gizmos.DrawWireCube(transform.position+transform.forward * swordbox.w, swordbox / 2);
            
        }

    }
}
