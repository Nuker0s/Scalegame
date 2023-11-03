using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playermovement : MonoBehaviour
{
    public Camera cam;
    public float speed;
    public float jumpforce;
    public float sense;
    public PlayerInput pinput;
    public InputAction move;
    public InputAction look;
    public InputAction jump;
    public Rigidbody rb;
    public bool jumpsched = false;
    public Transform groundchecker;
    public LayerMask ground;
    public float groundcheckrange;

    void Awake()
    {
        move = pinput.actions.FindAction("Move");
        look = pinput.actions.FindAction("Look");
        jump = pinput.actions.FindAction("Jump");

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lookero();
        if (jump.WasPressedThisFrame())
        {
            jumpsched = true;
        }
    }
    private void FixedUpdate()
    {
        movemento();
        jumperro();
    }
    public void movemento()
    {
        Vector2 minput = move.ReadValue<Vector2>();
        Vector3 moveforce = (minput.y * transform.forward) + (minput.x * transform.right);
        rb.AddForce(moveforce * Time.deltaTime * speed);
    }
    public void lookero()
    {
        Vector2 limput = look.ReadValue<Vector2>()*sense*Time.deltaTime;
        transform.Rotate(0, limput.x, 0);
        cam.transform.Rotate(limput.y*-1, 0, 0);
    }
    public void jumperro()
    {
        if (jumpsched & isgrounded())
        {
            rb.AddForce(0, jumpforce, 0);
            jumpsched = false;
        }
    }
    bool isgrounded()
    {
        return Physics.CheckSphere(groundchecker.position, groundcheckrange,ground);
    }
}
