using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class sword1 : MonoBehaviour
{
    public float damage;
    public float knockback;
    public float stun;
    public Transform swordtip;
    public Vector2 slashsize;
    public float cooldownTime;
    public bool isCooldown = false;
    //public bool side = false;
    public PlayerInput pinput;
    public InputAction fire;
    public VisualEffect trail;
    // Start is called before the first frame update
    void Start()
    {
        fire = pinput.actions.FindAction("Fire");
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

        trail.SetVector3("start", startpos);
        trail.SetVector3 ("end", swordtip.localPosition);
        trail.Play();

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
}
