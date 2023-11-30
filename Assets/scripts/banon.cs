using UnityEngine;
using UnityEngine.InputSystem;
public class cannon : MonoBehaviour
{
    public GameObject projectile;
    public PlayerInput pinput;
    public InputAction special;
    public float cooldown;
    public float timer;
    public AudioClip fire;
    // Start is called before the first frame update
    void Start()
    {
        special = pinput.actions.FindAction("Special");
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0) 
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0 && special.WasPressedThisFrame())
        {
            Fireprojectile();
        }


    }
    public void Fireprojectile() 
    {
        if (fire!=null)
        {
            onesound.playsound(transform.position, fire, globalvariables.sfxvolume);
        }
            timer = cooldown;
            Instantiate(projectile,transform.position,transform.rotation);
        
    }
}
